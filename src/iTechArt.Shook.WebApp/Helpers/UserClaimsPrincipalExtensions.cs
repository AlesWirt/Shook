using System;
using System.Security.Claims;

namespace iTechArt.Shook.WebApp.Helpers
{
    public static class UserClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal userClaimsPrincipal)
        {
            var userIdClaim = userClaimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userIdClaim, out var userId))
            {
                throw new ArgumentException("Wrong id.");
            }

            return userId;
        }
    }
}
