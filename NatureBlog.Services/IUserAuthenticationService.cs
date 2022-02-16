using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Services
{
    public interface IUserAuthenticationService
    {
        public Task<UserAuthenticationResult> RequestAuthenticatedUser(string userName, string password);
    }
}
