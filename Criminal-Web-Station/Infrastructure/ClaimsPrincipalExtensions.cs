namespace Criminal_Web_Station.Infrastructure
{
    using System.Security.Claims;

    public static class ClaimsPrincipalExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;
        public static bool IsAdmin(this ClaimsPrincipal user)
            => user.IsInRole(WebConstats.AdministratorRoleName);
    }
}
