using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DATA;

namespace Manager.Models
{
    public class incasariVM
    {
        public List<v_OrderTotals> totals { get; set; }

        public decimal totalIncasari
        {
            get
            {
                return totals.Sum(t => t.Total).Value;
            }
        }
    }
}