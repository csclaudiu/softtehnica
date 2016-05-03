using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DATA
{
    public class LocationMetadata
    {
        [Display(Name = "Location name")]
        public string location_name;
    }

    public class ProductMetadata
    {
        [Display(Name = "Product name")]
        public string name;

        [Display(Name = "The price for this product")]
        public string price;
    }

    public class ClientMetadata
    {
        [Display(Name = "First name")]
        public string firstname;

        [Display(Name = "Last name")]
        public string lastname;

        [Display(Name = "Email")]
        [EmailAddress]
        public string email;
    }
}