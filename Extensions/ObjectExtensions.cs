namespace Extensions;
public static class ObjectExtensions
{
    private static readonly JsonSerializerSettings Settings = new();
    static ObjectExtensions()
    {
        Settings.StringEscapeHandling = StringEscapeHandling.EscapeHtml;
        Settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
        Settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
        Settings.NullValueHandling = NullValueHandling.Ignore;
        Settings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
        Settings.Culture= global::System.Globalization.CultureInfo.InvariantCulture;
    }
    public static string JsonEncode<T>(this T obj)
    {
        return JsonConvert.SerializeObject(obj, Settings);
    }
    public static T JsonDecode<T>(this string json)
    {
        return JsonConvert.DeserializeObject<T>(json, Settings);
    }

    public static Dictionary<string, object> ToDictionary<T>(this T obj)
    {
        var json = obj.JsonEncode();
        return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
    }

    public static T JsonClone<T>(this T obj)
    {
        var json = obj.JsonEncode();
        return JsonConvert.DeserializeObject<T>(json);
    }
}