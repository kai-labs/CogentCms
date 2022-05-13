using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogentCms.Core.Auth
{
    public interface ICogentUser
    {
        int AppUserId { get; set; }
        string Username { get; set; }
        string FullName { get; set; }
    }
}
