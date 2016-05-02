using MODELS.Dto;
using Restaurant.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
    public class DashboardVM : BaseVM
    {
        public DashboardVM()
        {
            products = new ObservableCollection<ProductDto>();
            orderedProducts = new ObservableCollection<ProductDto>();
            orderedProducts.CollectionChanged += OrderedProducts_CollectionChanged;
            cmdAddToMenu = new RelayCommand<ProductDto>(AddProductToMenu);
            cmdRemoveFromMenu = new RelayCommand<ProductDto>(RemoveProductFromMenu);
        }

        private void OrderedProducts_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Notify("Total");
        }

        public ObservableCollection<ProductDto> products { get; set; }
        public ObservableCollection<ProductDto> orderedProducts { get; set; }

        private ClientDto _selectedClient;
        public ClientDto selectedClient
        {
            get { return _selectedClient; }
            set { _selectedClient = value; Notify("selectedClient"); }
        }

        public decimal Total
        {
            get { return orderedProducts.Select(op => op.price).Sum(); }
        }



        public RelayCommand<ProductDto> cmdAddToMenu { get; set; }
        private void AddProductToMenu(ProductDto item)
        {
            orderedProducts.Add(item);
        }
        public RelayCommand<ProductDto> cmdRemoveFromMenu { get; set; }
        private void RemoveProductFromMenu(ProductDto item)
        {
            orderedProducts.Remove(item);
        }
    }
}
