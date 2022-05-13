using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogentCms.Core.Auth
{
    public interface IAppUserService
    {
        bool DoesAppUserExist(string idProvider, string subjectId);
        AppUserData GetAppUser(string idProvider, string subjectId);
    }
}
