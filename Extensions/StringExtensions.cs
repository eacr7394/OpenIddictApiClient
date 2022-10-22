namespace Extensions;

public static class StringExtensions
{
    public static byte[] GetBytes(this string str)
    {
        return Encoding.Default.GetBytes(str);
    }
    public static string GetString(this byte[] bytes)
    {
        return Encoding.Default.GetString(bytes);
    }

    public static string GetEnvironmentVariable(this string str)
    {
        var envVarName = $"{str.Substring(1, str.Length - 2)}";
        var envVar = Environment.GetEnvironmentVariable(envVarName);
        if (envVar == null)
        {
            throw new ArgumentException($"{nameof(str)} '{envVarName}' environment variable not exists!");
        }
        return envVar;
    }
    public static string ToHex(this byte[] ba)
    {
        StringBuilder hex = new(ba.Length * 2);
        foreach (byte b in ba)
            hex.AppendFormat("{0:x2}", b);
        return hex.ToString();
    }

    public static string ToPassword(this string str)
    {
        using (SHA256 mySHA256 = SHA256.Create())
        {
            byte[] hashValue = mySHA256.ComputeHash(str.GetBytes());
            return hashValue.ToHex();
        }
    }

}