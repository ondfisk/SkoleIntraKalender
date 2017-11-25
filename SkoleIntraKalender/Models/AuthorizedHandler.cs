using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http;

namespace SkoleIntraKalender.Models
{
    public class AuthorizedHandler : DelegatingHandler
    {
        private readonly CalendarOptions _options;

        public AuthorizedHandler(IOptions<CalendarOptions> options)
        {
            _options = options.Value;

            var cookie = new Cookie(_options.CookieName, _options.CookieValue, "/", _options.CookieDomain);
            var container = new CookieContainer();
            container.Add(cookie);

            InnerHandler = new HttpClientHandler
            {
                CookieContainer = container
            };
        }
    }
}
