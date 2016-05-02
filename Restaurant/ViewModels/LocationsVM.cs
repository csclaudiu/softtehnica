using MODELS.Dto;
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
        }

        public ObservableCollection<LocationDto> avaibleLocations { get; set; }
    }
}
