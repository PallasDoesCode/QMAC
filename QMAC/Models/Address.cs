using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

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
            bool ipStatus = false;

            foreach (NetworkInterface adapters in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ipStatus.Equals(false))
                {
                    IPInterfaceProperties ipProperties = adapters.GetIPProperties();
                    foreach (IPAddressInformation unicast in ipProperties.UnicastAddresses)
                    {
                        ip = unicast.Address.ToString();
                        ipStatus = true;
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
                if ((address.Description.ToString().Contains("VirtualBox")) && (address.Description.ToString().Contains("VMware")))
                {
                    // do nothing   
                }

                // The else if allows us to avoid accidentally getting a MAC Address from a Tunnel adapter
                else if (address.NetworkInterfaceType.Equals(NetworkInterfaceType.Tunnel))
                {
                    // do nothing
                }

                else
                {
                    if (address.NetworkInterfaceType.Equals(NetworkInterfaceType.Ethernet) && address.OperationalStatus.Equals(OperationalStatus.Up))
                    {
                        macList.Add(address.GetPhysicalAddress().ToString() + "\t#\t" + sys.ComputerName + "-wired");
                    }

                    else if (address.NetworkInterfaceType.Equals(NetworkInterfaceType.Wireless80211) && address.OperationalStatus.Equals(OperationalStatus.Up))
                    {
                        macList.Add(address.GetPhysicalAddress().ToString() + "\t#\t" + sys.ComputerName + "-wireless");
                    }
                }
            }
            
            return macList;
        }
    }
}
