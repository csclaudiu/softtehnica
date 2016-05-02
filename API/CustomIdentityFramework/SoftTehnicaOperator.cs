using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.CustomIdentityFramework
{
    public class SoftTehnicaOperator : IUser<int>
    {
        public int Id
        {
            get; set;
        }

        public string UserName
        {
            get; set;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }


    }
}