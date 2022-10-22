namespace DefaultAuthentication;
public class TokenModel
{
    public int UserId { get; private set; }
    public string Name { get; private set; }
    public string EmailAddress { get; private set; }

    public TokenModel(int userId, [NotNull] string name, [NotNull] string emailAddress)
    {
        UserId = userId;
        Name = name;
        EmailAddress = emailAddress;
    }
}