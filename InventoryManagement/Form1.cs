using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace InventoryManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shirl\OneDrive\Documents\Inventorydb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            txtPassword.Text =null;
            TxtUserName.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomeForm home = new HomeForm();
            home.Show();

        }
        void adst() {
            con.Open();
            SqlDataAdapter ds = new SqlDataAdapter("Select Count(*) from UserTb1 where Uname='" + TxtUserName.Text + "' and Upassword='" + txtPassword.Text + "'", con);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                ManageCustomers cust = new ManageCustomers();
                cust.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }


            con.Close();
        }
    }
}
