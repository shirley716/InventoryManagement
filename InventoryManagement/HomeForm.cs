using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ManageProducts prod = new ManageProducts();
            prod.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageUsers users = new ManageUsers();
            users.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageCategories cati = new ManageCategories();
            cati.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManageCustomers cust = new ManageCustomers();
            cust.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ManageOrders order = new ManageOrders();
            order.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }
    }
}
