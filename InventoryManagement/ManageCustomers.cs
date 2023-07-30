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
    public partial class ManageCustomers : Form
    {
        public ManageCustomers()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shirl\OneDrive\Documents\Inventorydb.mdf;Integrated Security=True;Connect Timeout=30");
        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void populate()
        {
            try
            {
                con.Open();
                string Myquery = "select*from CustomerTb1";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                CustomerGV.DataSource = ds.Tables[0];
                con.Close();
            }
            catch { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer(Convert.ToInt32(customerID.Text),customerName.Text,customerPhone.Text);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into CustomerTb1 values(" + cust.CustID + ",'" + cust.CustName + "','" +  cust.CustPhone + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Successfully Added");
                con.Close();
                populate();
            }
            catch
            {

            }
        }

        private void ManageCustomers_Load(object sender, EventArgs e)
        {
                populate();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer(Convert.ToInt32(customerID.Text), customerName.Text, customerPhone.Text);
            try
            {
                con.Open();
                string myquery = "update CustomerTb1 set CustName='" + cust.CustName + "',CustPhone='" +
                    cust.CustPhone + "' where CustID='" + cust.CustID + "'";

                SqlCommand cmd = new SqlCommand(myquery, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Successfully Added");
                con.Close();
                populate();
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer(Convert.ToInt32(customerID.Text), customerName.Text, customerPhone.Text);

            if (customerID.Text == "")
            {
                MessageBox.Show("Enter the customer ID number.");
            }
            else
            {
                con.Open();
                string myquery = "delete from CustomerTb1 where CustID=" + cust.CustID + ";";
                SqlCommand cmd = new SqlCommand(myquery, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Successfully Deleted");
                con.Close();
                populate();
            }
        }

        private void CustomerGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            customerID.Text = CustomerGV.SelectedRows[0].Cells[0].Value.ToString();
            customerName.Text = CustomerGV.SelectedRows[0].Cells[1].Value.ToString();
            customerPhone.Text = CustomerGV.SelectedRows[0].Cells[2].Value.ToString();
            con.Open();
            SqlDataAdapter ads = new SqlDataAdapter("select Count(*) from OrderTb1 where CustID = "+customerID.Text+" ",con);
            DataTable dt = new DataTable();
            ads.Fill(dt);
            orderLabel.Text = dt.Rows[0][0].ToString();
            SqlDataAdapter ads1 = new SqlDataAdapter("select Sum(TotalAmount) from OrderTb1 where CustID = " + customerID.Text + " ", con);
            DataTable dt1 = new DataTable();
            ads1.Fill(dt1);
            orderAmountLabel.Text = dt1.Rows[0][0].ToString();
            SqlDataAdapter ads2 = new SqlDataAdapter("select Max(OrderDate) from OrderTb1 where CustID = " + customerID.Text + " ", con);
            DataTable dt2 = new DataTable();
            ads2.Fill(dt2);
            orderDateLabel.Text = dt2.Rows[0][0].ToString();

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HomeForm home = new HomeForm();
            home.Show();
            this.Hide();
        }
    }
}
