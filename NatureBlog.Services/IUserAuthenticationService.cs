using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Services
{
    public interface IUserAuthenticationService
    {
        public Task<bool> IsUserAuthentic(string userName, string password);
    }
}
