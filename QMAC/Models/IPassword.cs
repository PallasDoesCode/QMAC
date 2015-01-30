using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace QMAC.Models
{
    public interface IPassword
    {
        SecureString Password { get; }
    }
}
