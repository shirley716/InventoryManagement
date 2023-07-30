using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    internal class Order
    {
        private int _orderid;
        private int _custid;
        private string _custname;
        private DateTime _orderdate;
        private int _totalamount;
        public Order(int orderID, int custID, string custName, DateTime dt,int totalAmount) {
            this._orderid = orderID;
            this._custid = custID;
            this._custname = custName;
            this._orderdate = dt;
            this._totalamount = totalAmount;
        }
        public Order(int total)
        {
           
            this._totalamount = total;
 
        }
        public int orderID
        {
            get { return this._orderid; }
            set { this._orderid = value; }
        }
        public int custID
        {
            get { return this._custid; }
            set { this._custid = value; }
        }
        public string custName
        {
            get { return this._custname; }
            set { this._custname = value; }
        }
        public DateTime orderDate
        {
            get { return this._orderdate; }
            set { this._orderdate = value; }
        }
        public int totalAmount
        {
            get { return this._totalamount; }
            set { this._totalamount = value; }
        }
    }
}
