namespace Extensions;
public static class MySqlExtensions
{

    public static bool Is(this ulong bit)
    {
        return bit == 0?false: true;
    }

}