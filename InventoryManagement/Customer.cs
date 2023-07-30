using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    internal class Customer
    {

        private int _custid;
        private string _custname;
        private string _custphone;

        public Customer(int custID,string custName, string custPhone) {
            this._custid = custID;
            this._custname = custName;
            this._custphone = custPhone;
        }

        public int CustID
        {
            get {return this._custid; }
            set { this._custid = value; }
        }
        public string CustName
        {
            get { return this._custname; }
            set { this._custname = value; }
        }
        public string CustPhone
        {
            get { return this._custphone; }
            set { this._custphone = value; }
        }
    }
}
