using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QMAC.Models
{
    class SystemInfo
    {
        private string _computerName;

        public SystemInfo()
        {
            _computerName = getComputerName();
        }

        public string ComputerName
        {
            get { return _computerName; }
        }

        public string getComputerName()
        {
            return Environment.MachineName;
        }
    }
}
