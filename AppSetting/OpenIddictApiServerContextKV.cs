namespace AppSetting;
public class OpenIddictApiServerContextKV : IAppSetting
{
    public string Server { get; set; } = null!;
    public int Port { get; set; }
    public string Database { get; set; } = null!;

    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;

    public string CertificateFile { get; set; } = null!;
    public string CertificatePassword { get; set; } = null!;

    public void SetEnvironmentVariables()
    {
        User = User.GetEnvironmentVariable();
        Password = Password.GetEnvironmentVariable();

        CertificateFile = CertificateFile.GetEnvironmentVariable();
        CertificatePassword = CertificatePassword.GetEnvironmentVariable();
    }
}