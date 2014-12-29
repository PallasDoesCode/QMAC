using System.Net.NetworkInformation;

namespace QMAC.Extensions
{
    public static class NetworkExtension
    {
        public static bool isTunnel(this NetworkInterface adapter)
        {
            return adapter.NetworkInterfaceType == NetworkInterfaceType.Tunnel;
        }

        public static bool isVirtualBoxAdapter(this NetworkInterface adapter)
        {
            return adapter.Description.Contains("VirtualBox");
        }

        public static bool isVMwareAdapter(this NetworkInterface adapter)
        {
            return adapter.Description.Contains("VMware");
        }

        public static bool isEthernet(this NetworkInterface adapter)
        {
            string wireless = "Wireless".ToLowerInvariant();
            string wifi = "Wi-Fi".ToLowerInvariant();
            bool flag = false;


            if ((!adapter.Description.ToLowerInvariant().Contains(wireless) && !adapter.Description.ToLowerInvariant().Contains(wifi))
                && adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
            {
                flag = true;
            }

            return flag;
        }

        public static bool isWireless(this NetworkInterface adapter)
        {
            string wireless = "Wireless".ToLowerInvariant();
            string wifi = "Wi-Fi".ToLowerInvariant();

            if (adapter.Description.ToLowerInvariant().Contains(wireless))
            {
                return true;
            }

            else if (adapter.Description.ToLowerInvariant().Contains(wifi))
            {
                return true;
            }

            if ((adapter.Description.ToLowerInvariant().Contains(wireless) || adapter.Description.ToLowerInvariant().Contains(wifi)) 
                && adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
            {
                return true;
            }

            else if (adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
