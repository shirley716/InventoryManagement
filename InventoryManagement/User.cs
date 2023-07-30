using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class User
    {
        private string _uname;
        private string _ufullname;
        private string _upassword;
        private string _uphone;

        public User()
        {
        }

        public User(string Uname, string Ufullname,string Upassword, string Uphone) {
            this._uname = Uname;
            this._ufullname = Ufullname;
            this._upassword = Upassword;
            this._uphone = Uphone;
        }
        public string Uname


        {
            get { return this._uname; }
            set { this._uname = value; }
        }
        public string Ufullname {
            get { return this._ufullname; }
            set { this._ufullname = value; }
        }
        public string Upassword {
            get { return this._upassword; }
            set { this._upassword = value; }
        }
        public string Uphone {
            get { return this._uphone; }
            set { this._uphone = value; }
        }
    }

}
