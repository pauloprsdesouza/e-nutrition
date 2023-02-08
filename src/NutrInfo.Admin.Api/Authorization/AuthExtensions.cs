using System.Security.Claims;

namespace NutrInfo.Admin.Api.Authorization
{
    public static class AuthExtensions
    {
        public static int GetId(this ClaimsPrincipal claims)
        {
            return int.Parse(claims.FindFirstValue("user_id"));
        }
    }
}
