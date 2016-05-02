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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            VM = new LoginVM();
            this.DataContext = VM;
            VM.Username = "stoian.claudiu@gmail.com";
            VM.Password = "Aphrodit3";
        }
        public LoginVM VM { get; set; }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var _serviceToken = new TokenService();
            var result = await _serviceToken.getTokenForLoginAsync(VM.Username, VM.Password);
            if (result)
            {
                ApplicationState.SetValue("Token", _serviceToken.Token);
                var pageDashboard = new Dashboard();
                pageDashboard.Show();
                this.Close();
            }
            else
            {
                var msg = MessageBox.Show(_serviceToken.TokenError.error_description, "Login failed", MessageBoxButton.OKCancel);
            }



        }
    }
}
