namespace SkoleIntraKalender.Models;

public class CalendarOptions
{
    public Uri BaseAddress { get; set; }
    public string UrlFormatString { get; set; }
    public string ClassName { get; set; }
    public string CookieName { get; set; }
    public string CookieValue { get; set; }
    public string CookieDomain { get; set; }
    public Guid Password { get; set; }
}
