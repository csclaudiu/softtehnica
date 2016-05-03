using Restaurant.Services;
using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for OrdersHistory.xaml
    /// </summary>
    public partial class OrdersHistory : Window
    {
        public OrdersVM VM { get; set; }
        private OrdersService _OrdersSvc;

        public OrdersService OrdersSvc
        {
            get
            {
                if (_OrdersSvc == null)
                {
                    _OrdersSvc = new OrdersService(ApplicationState.GetValue<TokenDto>("Token"));
                }
                return _OrdersSvc;
            }
        }
        public OrdersHistory()
        {
            InitializeComponent();

            VM = new OrdersVM();
            this.DataContext = VM;

            foreach (var item in OrdersSvc.getAllOrders(VM.currentLocation))
            {
                VM.orders.Add(item);
            }
        }
    }
}
