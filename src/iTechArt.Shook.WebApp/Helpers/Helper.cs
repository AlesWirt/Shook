using System.Security.Claims;
using System;

namespace iTechArt.Shook.WebApp.Helpers
{
    public static class Helper
    {
        public static int GetUserIdClaimsPrincipal(ClaimsPrincipal userClaimsPrincipal)
        {
            var userIdClaim = userClaimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            if(!int.TryParse(userIdClaim, out var userId))
            {
                throw new ArgumentException("Wrong id.");
            }

            return userId;
        }
    }
}
