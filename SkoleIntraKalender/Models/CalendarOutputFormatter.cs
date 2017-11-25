using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Ical.Net;
using Ical.Net.Serialization;

namespace SkoleIntraKalender.Models
{
    public class CalendarOutputFormatter : TextOutputFormatter
    {
        public CalendarOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/calendar"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;

            var items = context.Object as IEnumerable<Item> ?? new[] { context.Object as Item };

            var calendar = items.ToCalendar().Serialize();

            await response.WriteAsync(calendar);
        }

        protected override bool CanWriteType(Type type)
        {
            if (typeof(Item).IsAssignableFrom(type) || typeof(IEnumerable<Item>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }
    }
}
