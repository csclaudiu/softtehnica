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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LocationsVM VM { get; set; }
        private LocationsService _LocationsSvc;

        public LocationsService LocationsSvc
        {
            get
            {
                if (_LocationsSvc == null)
                {
                    _LocationsSvc = new LocationsService();
                }
                return _LocationsSvc;
            }
        }

        public MainWindow()
        {
            InitializeComponent();


            VM = new LocationsVM();
            this.DataContext = VM;

            var allLocations = LocationsSvc.getAllLocations();
            foreach(var location in allLocations)
            {
                VM.avaibleLocations.Add(location);
            }
        }

        private void avaibleRestaurants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedLocation = avaibleRestaurants.SelectedItem as LocationDto;
            ApplicationState.SetValue("currentLocation", selectedLocation);

            var pageLogin = new Login();
            pageLogin.Show();
            this.Close();
        }
    }
}
