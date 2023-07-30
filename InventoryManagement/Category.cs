using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    internal class Category
    {
        private int _catiid;
        private string _catiname;
        public Category(int catiID, string catiName) {
            this._catiid = catiID;
            this._catiname = catiName;
        }
        public int CatiID
        {
            get {return this._catiid; }
            set {this._catiid = value; }
        }
        public string CatiName
        {
            get { return this._catiname; }
            set { this._catiname = value; }
        }
    }
}
