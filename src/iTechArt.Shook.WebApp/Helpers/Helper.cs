using System.Security.Claims;

namespace iTechArt.Shook.WebApp.Helpers
{
    public static class Helper
    {
        public static int GetUserIdClaimsPrincipal(ClaimsPrincipal userClaimsPrincipal)
        {
            var userIdClaim = userClaimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            var isConverted = int.TryParse(userIdClaim, out var userId);

            return userId;
        }
    }
}
