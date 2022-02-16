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
    public struct UserAuthenticationResult
    {
        public UserAuthenticationResult(bool isUserAuthenticated, int userId, string userName)
        {
            this.IsUserAuthenticated = isUserAuthenticated;
            this.Userid = userId;
            this.UserName = userName;
        }

        public bool IsUserAuthenticated { get; set; }
        public int Userid { get; set; }
        public string UserName { get; set; }
    }

    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly BlogDatabaseContext _db;
        private const string INVALID_USER_NAME = "INVALID USER";
        private const int INVALID_USER_ID = -1;

        public UserAuthenticationService(BlogDatabaseContext context)
        {
            _db = context;
        }

        public async Task<UserAuthenticationResult> RequestAuthenticatedUser(string userName, string password)
        {
            
            var user = await _db.Users
                .FirstOrDefaultAsync(x => x.UserName == userName);

            //Return invalid if user doesn't exist.
            if (user == null)
                return InvalidUser();

            var inputPasswordHash = PasswordUtilities.CreateHash(user.Salt + password);
            var isAuthenticUser = inputPasswordHash == user.PasswordHash;

            //Return invalid if password has doesn't match
            if (!isAuthenticUser)
                return InvalidUser();
   
            return new UserAuthenticationResult(
                isUserAuthenticated: isAuthenticUser, 
                userId: user.Id,
                userName: user.UserName);
        }

        private static UserAuthenticationResult InvalidUser()
        {
            return new UserAuthenticationResult(false, INVALID_USER_ID, INVALID_USER_NAME);
        }
    }
}
