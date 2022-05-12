using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogentCms.Core.Auth
{
    interface ICogentUser
    {
        string Username { get; set; }
        string FullName { get; set; }
    }
}
