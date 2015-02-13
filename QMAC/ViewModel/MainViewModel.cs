using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PropertyChanged;
using QMAC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;

namespace QMAC.ViewModel
{
    [ImplementPropertyChanged]
    public class MainViewModel : ViewModelBase
    {
        Address address;
        Location location;
        private RelayCommand<object> _exportCommand;
        private RelayCommand _closeCommand;
        private bool _saveIsChecked;

        public MainViewModel()
        {
            address = new Address();
            location = new Location();

            IsEnabled = true;
        }

        public List<string> LocationList
        {
            get { return location.site; }
        }

        public List<string> LocationsPicked { get; set; }

        public bool IsEnabled { get; set; }

        public string AppState { get; set; }

        public string Username { get; set; }

        public SecureString Password { get; set; }

        public string Address
        {
            get { return address.IPAddress; }
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
                    _exportCommand = new RelayCommand<object>(ExportList);
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
            if (passwordContainer != null)
            {
                var securePassword = passwordContainer.Password;
                var password = ConvertToUnsecureString(securePassword);

                NetworkCredential credentials = new NetworkCredential();
                credentials.UserName = Username;
                credentials.Password = password;
                credentials.Domain = "dcss.dekalbk12.org";

                string folder = String.Empty;

                if (IsEnabled)
                {
                    folder = "\\\\10.12.232.20\\TechDept\\Whitelist";
                }

                else
                {
                    folder = "Whitelist\\";
                }
                

                // Open the connection to the server
                using (new NetworkConnection(folder, credentials))
                {
                    foreach (string location in LocationsPicked)
                    {
                        string fileName = folder + "\\" + location + ".txt";

                        // Write out the lines to each text file
                        try
                        {
                            using (StreamWriter writer = new StreamWriter(fileName, true))
                            {
                                for (int i = 0; i < address.PhysicalAddresses.Count; i++)
                                {
                                    writer.WriteLine(address.PhysicalAddresses[i]);
                                }
                            }
                        }

                        catch (IOException ioe)
                        {
                            Console.WriteLine("The file was not written.");
                            Console.WriteLine(ioe.Message);
                            Console.WriteLine(ioe.StackTrace);
                        }
                    }

                    UpdateStatusBar("Success! Your MAC address(es) were successfully exported!");
                }
            }
        }

        private string ConvertToUnsecureString(SecureString password)
        {
            if (password == null)
            {
                return String.Empty;
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(password);
                return Marshal.PtrToStringUni(unmanagedString);
            }

            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
