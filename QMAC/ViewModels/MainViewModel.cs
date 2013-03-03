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
        private string _desktopPicked;
        private string _laptopPicked;
        private string _macAddress;

        public MainViewModel()
        {
            address = new Address();
            location = new Location();
            NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(AdapterType);
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

        public string DesktopPicked
        {
            get { return _desktopPicked; }
            set
            {
                _desktopPicked = value;
                OnPropertyChanged("DesktopPicked");
            }
        }

        public string LaptopPicked
        {
            get { return _laptopPicked; }
            set
            {
                _laptopPicked = value;
                OnPropertyChanged("LaptopPicked");
            }
        }

        public string Address
        {
            get { return _macAddress; }
            set
            {
                OnPropertyChanged("Address");
            }
        }

        public void AdapterType(object sender, EventArgs e)
        {
            foreach (NetworkInterface address in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Ignores any network adapters that were created by VirtualBox & VMware software
                if (!(address.Description.ToString().Contains("VirtualBox")) && !(address.Description.ToString().Contains("VMware")))
                {
                    if (address.NetworkInterfaceType.Equals(NetworkInterfaceType.Ethernet) && address.OperationalStatus.Equals(OperationalStatus.Up))
                    {
                        _macAddress = address.GetPhysicalAddress().ToString();
                    }

                    else if (address.NetworkInterfaceType.Equals(NetworkInterfaceType.Wireless80211) && address.OperationalStatus.Equals(OperationalStatus.Up))
                    {
                        //Dispatcher.CurrentDispatcher.BeginInvoke( ((Action) () => { this._macAddress = address.GetPhysicalAddress().ToString(); } ));
                    }
                }

                else
                {
                    // If we wanted to do something with the Virtualbox and VMware adapters then we would do it here.
                }
            }
        }
    }
}
