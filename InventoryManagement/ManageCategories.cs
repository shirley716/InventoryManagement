using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class ManageCategories : Form
    {
        public ManageCategories()
        {
            InitializeComponent();
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
                string Myquery = "select*from CategoryTb1";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                categoryGV.DataSource = ds.Tables[0];
                con.Close();
            }
            catch { }
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shirl\OneDrive\Documents\Inventorydb.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            Category cati = new Category(Convert.ToInt32(catigoryID.Text), catigoryName.Text.ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into CategoryTb1 values(" + cati.CatiID + ",'" + cati.CatiName + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Successfully Added");
                con.Close();
                populate();
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Category cati = new Category(Convert.ToInt32(catigoryID.Text), catigoryName.Text.ToString());
            if (cati.CatiID.ToString() == "" || cati.CatiName=="")
            {
                MessageBox.Show("Enter the category ID number.");
            }
            else
            {  
                con.Open();
                string pro = "select Count(*) from ProductTb1 where ProdCati = '" + cati.CatiName+"'";
                SqlDataAdapter ads = new SqlDataAdapter(pro,con);
                DataTable dt = new DataTable();
                ads.Fill(dt);
                string ct =  dt.Rows[0][0].ToString();
                if (ct != "0")
                {
                    MessageBox.Show("this category is in proudct list");
                }
                else {
                    string myquery = "delete from CategoryTb1 where CatiID=" + cati.CatiID + ";";
                    SqlCommand cmd = new SqlCommand(myquery, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Successfully Deleted");
                }

                
                con.Close();
                populate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Category cati = new Category(Convert.ToInt32(catigoryID.Text), catigoryName.Text.ToString());
            try
            {
                con.Open();
                string myquery = "update CategoryTb1 set CatiName='" + cati.CatiName + "' where CatiID='" + cati.CatiID + "'";
                SqlCommand cmd = new SqlCommand(myquery, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Successfully Added");
                con.Close();
                populate();
            }
            catch
            {

            }
        }

        private void ManageCategories_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void categoryGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            catigoryID.Text = categoryGV.SelectedRows[0].Cells[0].Value.ToString();
            catigoryName.Text = categoryGV.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HomeForm home = new HomeForm();
            home.Show();
            this.Hide();
        }
    }
}
