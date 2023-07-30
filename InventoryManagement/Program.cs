using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Application.Run(new ManageUsers());
            //Application.Run(new ManageCustomers());
            //Application.Run(new ManageCategories());
            //Application.Run(new ManageProducts());
            //Application.Run(new ManageOrders());
            //Application.Run(new ViewOrders());
        }
    }
}
