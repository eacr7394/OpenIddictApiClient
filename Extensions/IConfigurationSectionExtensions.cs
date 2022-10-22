namespace Extensions;
public static class IConfigurationSectionExtensions
{
    public static void BindConfigure<T>(this IConfigurationSection section, T options)
        where T : IAppSetting
    {
        section.Bind(options, c => c.BindNonPublicProperties = true);
        options.SetEnvironmentVariables();
    }
}