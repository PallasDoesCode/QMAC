using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace QMAC.Models
{
    class Address
    {
        private string _ethernetMAC;
        private string _wirelessMAC;
        private string _MACAddress;

        /*
         *  Using the get accessor below we will be able to read the
         *  MAC Address and assign it to the data binding of the
         *  TextBlock. Since we are not using a set accessor this will
         *  make the property Read-Only. Also since this property is read only,
         *  we have to assign the MAC address to the fields in this class.
         */

        public Address()
        {
            _ethernetMAC = getEthernetMAC();
            _wirelessMAC = getWirelessMAC();
            _MACAddress = getMacAddress();
        }

        public string EthernetMAC
        {
            get { return _ethernetMAC; }
        }

        public string WirelessMAC
        {
            get { return _wirelessMAC; }
        }

        public string PhysicalAddress
        {
            get { return _MACAddress; }
        }

        private string getEthernetMAC()
        {
            string mac = "";

            foreach (NetworkInterface address in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (address.NetworkInterfaceType.Equals(NetworkInterfaceType.Ethernet) && address.OperationalStatus.Equals(OperationalStatus.Up))
                {
                    mac = address.GetPhysicalAddress().ToString();
                }
            }

            return mac;
        }

        private string getWirelessMAC()
        {
            string mac = "";
            foreach (NetworkInterface address in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (address.NetworkInterfaceType.Equals(NetworkInterfaceType.Wireless80211) && address.OperationalStatus.Equals(OperationalStatus.Up))
                {
                    mac = address.GetPhysicalAddress().ToString();
                }
            }

            return mac;
        }

        private string getMacAddress()
        {
            string mac = "";
            return mac;
        }
    }
}
