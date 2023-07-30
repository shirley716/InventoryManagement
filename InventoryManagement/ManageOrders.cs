using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace InventoryManagement
{
    public partial class ManageOrders : Form
    {
        public ManageOrders()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shirl\OneDrive\Documents\Inventorydb.mdf;Integrated Security=True;Connect Timeout=30");
        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int num = 0;
        int uprice, totalprice, qty;
        string product;
        void populate()
        {
            try
            {
                con.Open();
                string Myquery = "select*from CustomerTb1";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, con);
                //SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                productsGV.DataSource = ds.Tables[0];
                con.Close();
            }
            catch { }
        }
        void populateProduct()
        {
            try
            {
                con.Open();
                string Myquery = "select*from ProductTb1";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, con);
                //SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                productCatiGV.DataSource = ds.Tables[0];
                con.Close();
            }
            catch { }
        }
        private void ManageOrders_Load(object sender, EventArgs e)
        {
            populate();
            populateProduct();
            fillcategory();
            populateTable();
        }
        DataTable table = new DataTable();
        void populateTable() {
            table.Columns.Add("Num");
            table.Columns.Add("Product");
            table.Columns.Add("Qty");
            table.Columns.Add("Uprice");
            table.Columns.Add("TotPrice");
            showGridView.DataSource = table;
        }
        void filterByCategory()
        {
            try
            {
                con.Open();
                string Myquery = "select*from ProductTb1 where ProdCati='" + searchComboOrders.SelectedValue.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, con);
                //SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                productCatiGV.DataSource = ds.Tables[0];
                con.Close();
            }
            catch { }
        }
        int flag = 0;
        int stock;
        private void productGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            stock = Convert.ToInt32(productCatiGV.SelectedRows[0].Cells[2].Value.ToString());
            product = productCatiGV.SelectedRows[0].Cells[1].Value.ToString();  
            uprice = Convert.ToInt32(productCatiGV.SelectedRows[0].Cells[3].Value.ToString());
            flag = 1;
        }

        private void productsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //OrderID.Text = productsGV.SelectedRows[0].Cells[0].Value.ToString();
            CustomerIDOrder.Text = productsGV.SelectedRows[0].Cells[0].Value.ToString();
            CustomerNameOrder.Text = productsGV.SelectedRows[0].Cells[1].Value.ToString();
        }
        int sum = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (orderQty.Text == "")
                MessageBox.Show("Enter The Quanity of Products");
            else if (flag == 0)
                MessageBox.Show("Select the Product");
            else if (Convert.ToInt32(orderQty.Text) > stock)
                MessageBox.Show("There are only "+stock + " in stock");
            else
            {
                
                qty = Convert.ToInt32(orderQty.Text);
                totalprice = uprice * qty;
                num = num + 1;   
                int i = table.Columns.Count;
                table.Rows.Add(num,product,qty,uprice, totalprice);
                showGridView.DataSource = table;
                flag = 0;
                sum = sum + totalprice;
                SumAmount.Text = "$" + sum;
                int id = Convert.ToInt32(productCatiGV.SelectedRows[0].Cells[0].Value.ToString());
                updateProduct(id);
            }
            
        }

        void updateProduct(int id) {
            con.Open();
            int newQty = stock-Convert.ToInt32(orderQty.Text);
            string query = "update ProductTb1 set ProdQty = "+newQty+" where  ProdID="+ id+ "";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();
            populateProduct();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (OrderID.Text == "" || CustomerIDOrder.Text == "" || CustomerNameOrder.Text == "" || SumAmount.Text == "")
            {
                MessageBox.Show("Pick the Items");
            }
            else {
                Order order = new Order(Convert.ToInt32(OrderID.Text), Convert.ToInt32(CustomerIDOrder.Text), CustomerNameOrder.Text, orderdate.Value,sum);
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into OrderTb1 values(" + order.orderID + "," + order.custID + ",'" + order.custName +"','" + order.orderDate + "'," + order.totalAmount + ")", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Order Successfully Added");
                    con.Close();
                    //populate();
                }
                catch
                {

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewOrders view = new ViewOrders();
            view.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HomeForm home = new HomeForm();
            home.Show();
            this.Hide();
        }

        private void SumAmount_TextChanged(object sender, EventArgs e)
        {

        }

        void fillcategory()
        {
            string query = "select *from categoryTb1";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr;
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("CatiName", typeof(string));
                rdr = cmd.ExecuteReader();
                dt.Load(rdr);
                searchComboOrders.ValueMember = "CatiName";
                searchComboOrders.DataSource = dt;
                con.Close();
                populate();
            }
            catch
            {

            }
        }
        private void searchComb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
