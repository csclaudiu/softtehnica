using MODELS.Dto;
using Restaurant.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
    public class BaseVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public LocationDto currentLocation
        {
            get
            {
                return ApplicationState.GetValue<LocationDto>("currentLocation");
            }
        }
    }
}
