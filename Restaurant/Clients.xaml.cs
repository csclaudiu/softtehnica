using MODELS.Dto;
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
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : Window
    {
        public ClientsVM VM { get; set; }
        private DashboardVM _dashboardVM;

        private ClientsService _ClientsSvc;

        public ClientsService ClientsSvc
        {
            get
            {
                if (_ClientsSvc == null)
                {
                    _ClientsSvc = new ClientsService(ApplicationState.GetValue<TokenDto>("Token"));
                }
                return _ClientsSvc;
            }
        }

        public Clients(DashboardVM passedViewModel)
        {
            InitializeComponent();

            VM = new ClientsVM();
            this.DataContext = VM;

            foreach (var item in ClientsSvc.getAllClients())
            {
                VM.clients.Add(item);
            }

            _dashboardVM = passedViewModel;
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            var newClient = new ClientDto()
            {
                email = VM.email,
                firstname = VM.firstname,
                lastname = VM.lastname,
            };
            if(ClientsSvc.addClient(ref newClient))
            {
                VM.clients.Add(newClient);
                VM.clearInsertForm();
            }
        }

        private void avaibleClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _dashboardVM.selectedClient = avaibleClients.SelectedItem as ClientDto;
            this.Close();
        }
    }
}
