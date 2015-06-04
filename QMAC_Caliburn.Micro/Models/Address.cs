using QMAC.Extensions;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace QMAC.Models
{
    class Address
    {
        SystemInfo sys;
        private string _ipAddress;
        private List<string> _addressList;

        /*
         *  Using the get accessor below we will be able to read the
         *  IP Address and assign it to the data binding of the
         *  TextBlock. Since we are not using a set accessor this will
         *  make the property Read-Only. Also since this property is read only,
         *  we have to assign the IP address to the fields in this class.
         */

        public Address()
        {
            sys = new SystemInfo();
            _ipAddress = getCurrentIPAddress();
            _addressList = getMacAddresses();
        }

        public List<string> PhysicalAddresses
        {
            get { return _addressList; }
        }

        public string IPAddress
        {
            get { return _ipAddress; }
        }

        private string getCurrentIPAddress()
        {
            string ip = "";

            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                if ((adapter.isEthernet() || adapter.isWireless()) && (!adapter.isVirtualBoxAdapter())
                    && (!adapter.isVMwareAdapter()))
                {
                    IPInterfaceProperties ipProperties = adapter.GetIPProperties();
                    foreach (UnicastIPAddressInformation address in ipProperties.UnicastAddresses)
                    {
                        if (address.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork
                            && adapter.OperationalStatus == OperationalStatus.Up)
                        {
                            ip = address.Address.ToString();
                        }
                    }
                }
            }

            return ip;
        }

        private List<string> getMacAddresses()
        {
            List<string> macList = new List<string>();
            foreach (NetworkInterface address in NetworkInterface.GetAllNetworkInterfaces())
            {
                // We want the application to ignore any network adapters that were created by VirtualBox & VMware software
                // That is why we have this statement.
                if ((address.isVirtualBoxAdapter()) && (address.isVMwareAdapter()))
                {
                    // do nothing   
                }

                // The else if allows us to avoid accidentally getting a MAC Address from a Tunnel adapter
                else if (address.isTunnel())
                {
                    // do nothing
                }

                else
                {
                    if (address.isEthernet())
                    {
                        macList.Add(address.GetPhysicalAddress().ToString() + "\t#\t" + sys.ComputerName + "-wired");
                    }

                    else if (address.isWireless())
                    {
                        macList.Add(address.GetPhysicalAddress().ToString() + "\t#\t" + sys.ComputerName + "-wireless");
                    }
                }
            }

            return macList;
        }
    }
}
