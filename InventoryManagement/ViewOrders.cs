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
    public partial class ViewOrders : Form
    {
        public ViewOrders()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shirl\OneDrive\Documents\Inventorydb.mdf;Integrated Security=True;Connect Timeout=30");
        void populateorders() {
            con.Open();
            string myquery = "select * from OrderTb1";
            SqlDataAdapter da = new SqlDataAdapter(myquery,con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            viewOrderGV.DataSource = ds.Tables[0];
          
        }

        private void ViewOrders_Load(object sender, EventArgs e)
        {
            populateorders();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void viewOrderGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {           
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK) {
                printDocument1.Print();
            }        
            //}        
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Order Summary", new Font("Century", 30, FontStyle.Bold),Brushes.Red,new Point(230,130));
            e.Graphics.DrawString("Order Id:"+ viewOrderGV.SelectedRows[0].Cells[0].Value.ToString(), new Font("Century", 20, FontStyle.Bold), Brushes.Black, new Point(80,250));
            e.Graphics.DrawString("Customer ID:" + viewOrderGV.SelectedRows[0].Cells[1].Value.ToString(), new Font("Century", 20, FontStyle.Bold), Brushes.Black, new Point(80, 290));
            e.Graphics.DrawString("Customer Name:" + viewOrderGV.SelectedRows[0].Cells[2].Value.ToString(), new Font("Century", 20, FontStyle.Bold), Brushes.Black, new Point(80, 330));
            e.Graphics.DrawString("Order Date:" + viewOrderGV.SelectedRows[0].Cells[3].Value.ToString(), new Font("Century", 20, FontStyle.Bold), Brushes.Black, new Point(80, 370));
            e.Graphics.DrawString("Total Amount:" + viewOrderGV.SelectedRows[0].Cells[4].Value.ToString(), new Font("Century", 20, FontStyle.Bold), Brushes.Black, new Point(80, 410));
        }



    }
}
