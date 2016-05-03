using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Dto
{
    public class OrderDto
    {
        public int id { get; set; }
        public System.DateTime date { get; set; }
        public string comment { get; set; }

        public ClientDto client { get; set; }
        public LocationDto location { get; set; }
        public List<ProductDto> orderitems { get; set; }
    }
}
