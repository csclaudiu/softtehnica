using MODELS.Dto;
using Restaurant.Services;
using Restaurant.ViewModels;
using RestSharp;
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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public DashboardVM VM { get; set; }
        private ProductsService _ProductsSvc;
        private OrdersService _OrdersSvc;

        public ProductsService ProductsSvc
        {
            get {
                if (_ProductsSvc == null)
                {
                    _ProductsSvc = new ProductsService(ApplicationState.GetValue<TokenDto>("Token"));
                }
                return _ProductsSvc;
            }
        }
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

        public Dashboard()
        {
            InitializeComponent();
            VM = new DashboardVM();
            this.DataContext = VM;

            foreach (var item in ProductsSvc.getAllProducts())
            {
                VM.products.Add(item);
            }
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            var clientsPage = new Clients(VM);
            clientsPage.ShowDialog();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            var newOrder = new OrderDto()
            {
                client = VM.selectedClient,
                location = VM.currentLocation
            };
            newOrder.orderitems = new List<ProductDto>();
            foreach(var orderedProd in VM.orderedProducts)
            {
                newOrder.orderitems.Add(orderedProd);
            }
            if (OrdersSvc.addOrder(ref newOrder))
            {
                VM.orderedProducts.Clear();
                VM.selectedClient = null;
            }
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            var ordersHistoryPage = new OrdersHistory();
            ordersHistoryPage.ShowDialog();
        }
    }
}
