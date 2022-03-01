using System.Security.Claims;
using System.Security.Principal;

namespace NatureBlog.Web.Utilities
{
    public static class PrincipalUtilityExtensions
    {
        public static int GetUserIdFromClaims(this ClaimsPrincipal identity)
        {
            //This claim should be set when user logs in. It's merely the user id from the database.
            var userIdClaim = identity.FindFirst(ClaimTypes.Sid)?.Value ?? String.Empty;
            var outUserId = -1;

            //Make sure the string returned from principal is an int. If not, return -1.
            if (int.TryParse(userIdClaim, out outUserId) == false)
                throw new DataMisalignedException("Expected user id to be an int. Could not cast claim value.");

            return outUserId;
        }
    }
}
