using QMAC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Input;
using System.Windows.Threading;

namespace QMAC.ViewModels
{
    class MainViewModel: ViewModelBase
    {
        Address address;
        Location location;
        private List<string> _locationPicked;
        private string _ipAddress;
        private string _message;
        private DelegateCommand _exportCommand;

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

        public List<string> LocationsPicked
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

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        public ICommand ExportCommand
        {
            get
            {
                if (_exportCommand == null)
                {
                    // We are passing the o object to the DelegateCommand class and telling it
                    // to execute the ExportList method.
                    _exportCommand = new DelegateCommand((o) => this.ExportList());
                }

                return _exportCommand;
            }
        }

        public void ExportList()
        {
            string folder = "\\\\10.12.232.20\\TechDept\\Whitelist";
            string fileName = folder + "\\" + LocationsPicked + ".txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    for (int i = 0; i < address.PhysicalAddresses.Count; i++)
                    {
                        writer.WriteLine(address.PhysicalAddresses[i]);
                    }
                }

                Message = "The MAC Address was exported successfully.";
            }

            catch (IOException ioe)
            {
                Console.WriteLine("The file was not written.");
                Console.WriteLine(ioe.Message);
                Console.WriteLine(ioe.StackTrace);
            }
        }
    }
}
