using MODELS.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
    public class OrdersVM : BaseVM
    {
        public OrdersVM()
        {
            orders = new ObservableCollection<OrderDto>();
        }
        public ObservableCollection<OrderDto> orders { get; set; }
    }
}
