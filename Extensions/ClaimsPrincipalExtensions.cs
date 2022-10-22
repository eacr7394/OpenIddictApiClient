namespace Extensions;
public static class ClaimsPrincipalExtensions
{
    public static string Claim(this ClaimsPrincipal obj, string claimName)
    {
        return obj.Claims.Where(x => x.Type == claimName).Select(x => x.Value).Single();
    }
}