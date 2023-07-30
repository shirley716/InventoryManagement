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
    public partial class ManageProducts : Form
    {
        public ManageProducts()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shirl\OneDrive\Documents\Inventorydb.mdf;Integrated Security=True;Connect Timeout=30");
        void fillcategory() {
            string query = "select *from categoryTb1";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr;
            try {
                con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("CatiName",typeof(string));
                rdr = cmd.ExecuteReader();
                dt.Load(rdr);
                CatCombo.ValueMember = "CatiName";
                CatCombo.DataSource = dt;
                searchComb.ValueMember = "CatiName";
                searchComb.DataSource = dt;
                con.Close();
                populate();
            }
            catch { 
            
            }
        }
        
        private void ManageProducts_Load(object sender, EventArgs e)
        {
            fillcategory();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void populate()
        {
            try
            {
                con.Open();
                string Myquery = "select*from ProductTb1";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, con);
                //SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                productGV.DataSource = ds.Tables[0];
                con.Close();
            }
            catch { }
        }

        void filterByCategory()
        {
            try
            {
                con.Open();
                string Myquery = "select*from ProductTb1 where ProdCati='"+searchComb.SelectedValue.ToString()+"'";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, con);
                //SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                productGV.DataSource = ds.Tables[0];
                con.Close();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product prod = new Product(Convert.ToInt32(prodID.Text),prodName.Text,Convert.ToInt32(productQty.Text),Convert.ToInt32(prodPrice.Text),prodDesc.Text, CatCombo.SelectedValue.ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into ProductTb1 values('" + prod.ProdID + "','" + prod.ProdName + "'" +
                    "," + prod.ProductQty + "," + prod.ProductPrice + ",'"+prod.ProductDesc+"','"+prod.ProductCati+"')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Successfully Added");
                con.Close();
                populate();
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (prodID.Text == "")
            {
                MessageBox.Show("Enter the productID.");
            }
            else
            {
                con.Open();
                string myquery = "delete from ProductTb1 where ProdID='" + prodID.Text + "';";
                SqlCommand cmd = new SqlCommand(myquery, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Successfully Deleted");
                con.Close();
                populate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product prod = new Product(Convert.ToInt32(prodID.Text), prodName.Text, Convert.ToInt32(productQty.Text), Convert.ToInt32(prodPrice.Text), prodDesc.Text, CatCombo.SelectedValue.ToString());
            try
            {
                con.Open();
                string myquery = "update ProductTb1 set ProdName='" +prod.ProdName + "',ProdQty=" + prod.ProductQty + ",ProdPrice=" +
                    prod.ProductPrice + ",ProdDesc='"+prod.ProductDesc+ "',ProdCati='"+ prod.ProductCati+ "' where ProdID=" +prod.ProdID + "";

                SqlCommand cmd = new SqlCommand(myquery, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Successfully updated");
                con.Close();
                populate();
            }
            catch
            {

            }
        }

        private void productGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            prodID.Text = productGV.SelectedRows[0].Cells[0].Value.ToString();
            prodName.Text = productGV.SelectedRows[0].Cells[1].Value.ToString();
            productQty.Text = productGV.SelectedRows[0].Cells[2].Value.ToString();
            prodPrice.Text = productGV.SelectedRows[0].Cells[3].Value.ToString();
            prodDesc.Text = productGV.SelectedRows[0].Cells[4].Value.ToString();
            CatCombo.SelectedValue = productGV.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            filterByCategory();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void searchComb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            HomeForm home = new HomeForm();
            home.Show();
            this.Hide();
        }
    }
}
