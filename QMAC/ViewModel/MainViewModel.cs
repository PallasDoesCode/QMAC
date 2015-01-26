using GalaSoft.MvvmLight;
using PropertyChanged;
using QMAC.Models;
using QMAC.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;

namespace QMAC.ViewModel
{
    [ImplementPropertyChanged]
    public class MainViewModel : ViewModelBase
    {
        Address address;
        Location location;
        private DelegateCommand _exportCommand;

        public MainViewModel()
        {
            address = new Address();
            location = new Location();
        }

        public List<string> LocationList
        {
            get { return location.site; }
        }

        public List<string> LocationsPicked { get; set; }

        public string Address
        {
            get { return address.IPAddress; }
        }

        public string Message { get; set; }

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
