using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manager.CustomUserStore
{
    public class SoftTehnicaUser : IUser<int>
    {
        public int Id
        {
            get; set;
        }
        

        public string UserName
        {
            get;set;
        }

        public string Email
        {
            get; set;
        }

        public string PasswordHash
        {
            get; set;
        }
    }
}