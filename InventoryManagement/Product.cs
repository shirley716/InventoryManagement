using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    internal class Product
    {
        private int _prodid;
        private string _prodname;
        private int _prodqty;
        private int _prodprice;
        private string _proddesc;
        private string _prodcati;
        public Product(int prodID, string prodName, int prodQty, int prodPrice, string prodDesc, string prodCati) {
            this._prodid = prodID;
            this._prodname = prodName;
            this._prodqty = prodQty;
            this._prodprice = prodPrice;
            this._proddesc = prodDesc;
            this._prodcati = prodCati;
        }
        public int ProdID
        {
            get { return this._prodid; }
            set { this._prodid = value; }
        }
        public string ProdName {
            get { return this._prodname; }
            set { this._prodname = value; }
        }
        public int ProductQty {
            get { return this._prodqty; }
            set { this._prodqty = value; }
        }
        public int ProductPrice
        {
            get { return this._prodprice; }
            set { this._prodprice = value; }
        }
        public string ProductDesc {
            get { return this._proddesc; }
            set { this._proddesc = value; }
        }
        public string ProductCati {
            get { return this._prodcati; }
            set { this._prodcati = value; }
        }
    }
}
