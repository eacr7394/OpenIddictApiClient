namespace DefaultAuthentication;
public class OpenIddictBasicAuthScheme
{
    public const string AuthenticationScheme = "Basic";
    public const string NToken = $"{AuthenticationScheme} (?<token>.*)";
}