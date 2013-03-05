using QMAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Threading;

namespace QMAC.ViewModels
{
    class MainViewModel: ViewModelBase
    {
        Address address;
        Location location;
        private string _locationPicked;
        private string _ipAddress;

        public MainViewModel()
        {
            address = new Address();
            location = new Location();
            _ipAddress = address.IPAddress;
        }

        public List<string> LocationList
        {
            get { return location.site; }
            set
            {
                OnPropertyChanged("LocationList");
            }
        }

        public string LocationPicked
        {
            get { return _locationPicked; }
            set
            {
                _locationPicked = value;
                OnPropertyChanged("LocationPicked");
            }
        }

        public string Address
        {
            get { return _ipAddress; }
            set
            {
                OnPropertyChanged("Address");
            }
        }
    }
}
