using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PropertyChanged;
using QMAC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;

namespace QMAC.ViewModel
{
    [ImplementPropertyChanged]
    public class MainViewModel : ViewModelBase
    {
        Address address;
        Location location;
        SystemInfo system;
        private RelayCommand<object> _exportCommand;
        private RelayCommand _closeCommand;
        private bool _saveIsChecked;

        public MainViewModel()
        {
            address = new Address();
            location = new Location();
            system = new SystemInfo();

            IsEnabled = true;
        }

        public ObservableCollection<string> LocationList
        {
            get { return location.Sites; }
        }

        public List<string> SelectedLocations { get; set; }

        public bool IsEnabled { get; set; }

        public string AppState { get; set; }

        public string Username { get; set; }

        public SecureString Password { get; set; }

        public string SystemInformation
        {
            get { return (system.ComputerName + " - " + address.IPAddress); }
        }

        public string Message { get; set; }

        public bool LocalSaveIsChecked
        {
            get
            {
                return _saveIsChecked;
            }

            set
            {
                _saveIsChecked = value;

                /*
                 * By default the Local Save feature is disabled because of this
                 * we want to set the login textboxes IsEnabled feature to be opposite
                 * of the local save. That way when the application is launched the 
                 * local save feature is disabled and the login feature is enabled then
                 * when the local save feature is turned on the login feature will be disabled
                 */
                IsEnabled = !value;

                if (value)
                {
                    UpdateStatusBar("Local Save Enabled");
                }

                else
                {
                    UpdateStatusBar("Local Save Disabled");
                }
                
                RaisePropertyChanged("LocalSaveCheck");
            }
        }

        public RelayCommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(Close);
                }

                return _closeCommand;
            }
        }

        public RelayCommand<object> ExportCommand
        {
            get
            {
                if (_exportCommand == null)
                {
                    // We are passing the o object to the DelegateCommand class and telling it
                    // to execute the ExportList method.
                    //_exportCommand = new RelayCommand<object>(ExportList);
                }

                return _exportCommand;
            }
        }

        public void UpdateStatusBar(string status)
        {
            AppState = status;
        }

        public void Close()
        {
            this.Close();            
        }

        public void ExportList(object parameter)
        {
            var passwordContainer = parameter as IPassword;
            NetworkCredential credentials;
            string folder = String.Empty;

            if (passwordContainer != null && IsEnabled == true)
            {
                var securePassword = passwordContainer.Password;

                credentials = new NetworkCredential();
                credentials.UserName = Username;
                credentials.SecurePassword = securePassword;
                credentials.Domain = "dcss.dekalbk12.org";

                folder = "\\\\10.12.232.20\\TechDept\\Whitelist";
                WriteToNetworkFolder(folder, credentials);
            }

            else
            {
                folder = "Whitelist\\";
                WriteToLocalFolder(folder);
            }
        }

        private void WriteToNetworkFolder(string folder, NetworkCredential credentials)
        {
            // Open the connection to the server
            using (new NetworkConnection(folder, credentials))
            {
            //    foreach (var location in SelectedItems)
            //    {
            //        string fileName = folder + "\\" + location + ".txt";

            //        // Write out the lines to each text file
            //        try
            //        {
            //            using (StreamWriter writer = new StreamWriter(fileName, true))
            //            {
            //                for (int i = 0; i < address.PhysicalAddresses.Count; i++)
            //                {
            //                    writer.WriteLine(address.PhysicalAddresses[i]);
            //                }
            //            }
            //        }

            //        catch (IOException ioe)
            //        {
            //            Console.WriteLine("The file was not written.");
            //            Console.WriteLine(ioe.Message);
            //            Console.WriteLine(ioe.StackTrace);
            //        }
            //    }

            //    UpdateStatusBar("Success! Your MAC address(es) were successfully exported!");
            }
        }

        private void WriteToLocalFolder(string folder)
        {
            //foreach (var location in SelectedItems)
            //{
            //    string fileName = folder + "\\" + location + ".txt";

            //    // Write out the lines to each text file
            //    try
            //    {
            //        using (StreamWriter writer = new StreamWriter(fileName, true))
            //        {
            //            for (int i = 0; i < address.PhysicalAddresses.Count; i++)
            //            {
            //                writer.WriteLine(address.PhysicalAddresses[i]);
            //            }
            //        }
            //    }

            //    catch (IOException ioe)
            //    {
            //        Console.WriteLine("The file was not written.");
            //        Console.WriteLine(ioe.Message);
            //        Console.WriteLine(ioe.StackTrace);
            //    }
            //}

            UpdateStatusBar("Success! Your MAC address(es) were successfully exported!");
        }
    }
}
