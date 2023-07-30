using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace InventoryManagement
{
    public partial class ManageUsers : Form
    {
        public ManageUsers()
        {
            InitializeComponent();
 
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shirl\OneDrive\Documents\Inventorydb.mdf;Integrated Security=True;Connect Timeout=30");
        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void populate() {
            try {
                con.Open();
                string Myquery = "select*from UserTB1";
                SqlDataAdapter da = new SqlDataAdapter(Myquery,con);
                //SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                UsersGV.DataSource = ds.Tables[0];
                con.Close();
            } catch { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User(userTab.Text.ToString(), fullNameTab.Text.ToString(), passwordTab.Text.ToString(), telephoneTab.Text.ToString()); ;
            try
            {
                con.Open();
                //SqlCommand cmd = new SqlCommand("insert into UserTb1 values('" + userTab.Text + "','" + fullNameTab.Text + "'" +
                    //",'" + passwordTab.Text + "','" + telephoneTab.Text + "')", con);
                SqlCommand cmd = new SqlCommand("insert into UserTb1 values('" + user.Uname + "','" + user.Ufullname + "'" +
                    ",'" +user.Upassword + "','" + user.Uphone + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Added");
                con.Close();
                populate();
            }
            catch { 
                
            }
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User user = new User(userTab.Text.ToString(), fullNameTab.Text.ToString(), passwordTab.Text.ToString(), telephoneTab.Text.ToString()); ;
            if (user.Uphone == "")
            {
                MessageBox.Show("Enter the users phone number.");
            }
            else {
                con.Open();
                string myquery = "delete from UserTb1 where Uphone='"+ user.Uphone + "';";
                SqlCommand cmd = new SqlCommand(myquery,con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Deleted");
                con.Close();
                populate();
            }
        }

        private void UsersGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            userTab.Text = UsersGV.SelectedRows[0].Cells[0].Value.ToString();
            fullNameTab.Text = UsersGV.SelectedRows[0].Cells[1].Value.ToString();
            passwordTab.Text= UsersGV.SelectedRows[0].Cells[2].Value.ToString();
            telephoneTab.Text = UsersGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User user = new User(userTab.Text.ToString(), fullNameTab.Text.ToString(), passwordTab.Text.ToString(), telephoneTab.Text.ToString()); ;
            try
            {
                con.Open();
                string myquery = "update UserTb1 set Uname='"+user.Uname+"',Ufullname='"+ user.Ufullname + "',Upassword='"+ 
                    user.Upassword+ "' where Uphone='"+user.Uphone+"'";

                SqlCommand cmd = new SqlCommand(myquery, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Added");
                con.Close();
                populate();
            } 
            catch { 
            
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HomeForm home = new HomeForm();
            home.Show();
            this.Hide();
        }
    }
}
