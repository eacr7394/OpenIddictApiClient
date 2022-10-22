using AppSetting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace OrmModel.OpenIddictApiServer;
public partial class OpenIddictApiServerContext
{
    public static string GetConnectionString(OpenIddictApiServerContextKV openIddictApiServerContextKV)
    {
        var connectionString = $"Server={openIddictApiServerContextKV.Server};";
        connectionString += $"User={openIddictApiServerContextKV.User};";
        connectionString += $"Password={openIddictApiServerContextKV.Password};";
        connectionString += $"Database={openIddictApiServerContextKV.Database};";
        connectionString += $"CertificateFile={openIddictApiServerContextKV.CertificateFile};";
        connectionString += $"CertificatePassword={openIddictApiServerContextKV.CertificatePassword};";

#if DEBUG
        connectionString += $"SslMode=VerifyCA;";
#else
            connectionString += $"SslMode=VerifyFull;";
#endif


        return connectionString;
    }

    private readonly OpenIddictApiServerContextKV _openIddictApiServerContextKV;
    public OpenIddictApiServerContext(IOptions<OpenIddictApiServerContextKV> openIddictApiServerContextKV,
        DbContextOptions<OpenIddictApiServerContext> options) : base(options)
    { 
        _openIddictApiServerContextKV = openIddictApiServerContextKV.Value;
        var conn = Database.GetDbConnection();
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = @$"set global net_buffer_length  = {int.MaxValue};
                                 set global max_allowed_packet = {int.MaxValue};";
        cmd.ExecuteNonQuery();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = GetConnectionString(_openIddictApiServerContextKV);
            var serverVersion = ServerVersion.AutoDetect(connectionString);

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseMySql(connectionString, serverVersion)
                .EnableSensitiveDataLogging()
                .EnableThreadSafetyChecks()
                .EnableDetailedErrors();

        }


    }

}
