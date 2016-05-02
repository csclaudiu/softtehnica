using MODELS.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
    public class ClientsVM : BaseVM
    {
        public ClientsVM()
        {
            clients = new ObservableCollection<ClientDto>();
        }
        public ObservableCollection<ClientDto> clients { get; set; }

        private string _firstname;

        public string firstname
        {
            get { return _firstname; }
            set { _firstname = value; Notify("firstname"); }
        }

        private string _lastname;

        public string lastname
        {
            get { return _lastname; }
            set { _lastname = value; Notify("lastname"); }
        }

        private string _email;

        public string email
        {
            get { return _email; }
            set { _email = value; Notify("email"); }
        }

        public void clearInsertForm()
        {
            email = string.Empty;
            firstname = string.Empty;
            lastname = string.Empty;
        }

    }
}
