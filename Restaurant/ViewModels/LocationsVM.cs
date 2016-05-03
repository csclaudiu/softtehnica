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
    public class LocationsVM : BaseVM
    {
        public LocationsVM()
        {
            avaibleLocations = new ObservableCollection<LocationDto>();
            cmdRestaurantSelected = new RelayCommand<LocationDto>(restaurantSelected);
        }

        public ObservableCollection<LocationDto> avaibleLocations { get; set; }

        public RelayCommand<LocationDto> cmdRestaurantSelected { get; set; }
        private void restaurantSelected(LocationDto rest)
        {
            ApplicationState.SetValue("currentLocation", rest);
        }
    }
}
