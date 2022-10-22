namespace DefaultAuthentication;
public class OpenIddictBasicAuthHandler : AuthenticationHandler<OpenIddictBasicAuthSchemeOptions>
{

    public OpenIddictBasicAuthHandler(
            [NotNull] IOptionsMonitor<OpenIddictBasicAuthSchemeOptions> options,
            [NotNull] ILoggerFactory loggerFactory,
            [NotNull] UrlEncoder encoder,
            [NotNull] ISystemClock clock)
           : base(options, loggerFactory, encoder, clock)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        TokenModel model;

        // validation comes in here
        if (!Request.Headers.ContainsKey(HeaderNames.Authorization))
        {
            return Task.FromResult(AuthenticateResult.Fail("Header Not Found."));
        }

        var header = Request.Headers[HeaderNames.Authorization].ToString();
        var tokenMatch = Regex.Match(header, OpenIddictBasicAuthScheme.NToken);

        if (tokenMatch.Success)
        {
            // the token is captured in this group
            // as declared in the Regex
            var token = tokenMatch.Groups["token"].Value;

            try
            {
                // convert the input token down from Base64 into normal
                byte[] fromBase64String = Convert.FromBase64String(token);
                var parsedToken = Encoding.UTF8.GetString(fromBase64String);

                // deserialize the JSON string obtained from the byte array
                model = JsonConvert.DeserializeObject<TokenModel>(parsedToken)!;
            }
            catch (Exception ex)
            {
                Logger.LogTrace("Exception Occured while Deserializing: " + ex, ex);
                return Task.FromResult(AuthenticateResult.Fail("TokenParseException"));
            }

            // success branch
            // generate authTicket
            // authenticate the request

            /* todo */
        }

        // failure branch
        // return failure
        // with an optional message
        return Task.FromResult(AuthenticateResult.Fail("Model is Empty"));
    }
}