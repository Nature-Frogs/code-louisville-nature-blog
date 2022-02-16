using Microsoft.EntityFrameworkCore;
using NatureBlog.DAL;
using NatureBlog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly BlogDatabaseContext _db;

        public UserAuthenticationService(BlogDatabaseContext context)
        {
            _db = context;
        }

        public async Task<bool> IsUserAuthentic(string userName, string password)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(x => x.UserName == userName);

            var inputPasswordHash = PasswordUtilities.CreateHash(user.Salt + password);

            return inputPasswordHash == user.PasswordHash;
        }

    }
}
