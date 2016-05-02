using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
    public class LoginVM : BaseVM
    {
        private string _Username;

        public string Username
        {
            get { return _Username; }
            set { _Username = value; Notify("Login"); }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; Notify("Password"); }
        }

    }
}
