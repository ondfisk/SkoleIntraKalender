using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SkoleIntraKalender.Models
{
    public static class Extensions
    {
        private static readonly DateTimeOffset Epoch = new DateTimeOffset(new DateTime(1970, 1, 1), TimeSpan.FromHours(0));

        public static long ToMillisecondsSinceEpoch(this DateTime dateTime)
        {
            var utc = dateTime.ToUniversalTime();
            var timeSpan = utc - Epoch;

            return (long)timeSpan.TotalMilliseconds;
        }

        public static int ToSecondsSinceEpoch(this DateTime dateTime)
        {
            var utc = dateTime.ToUniversalTime();
            var timeSpan = utc - Epoch;

            return (int)timeSpan.TotalSeconds;
        }

        public static DateTime ToDateTime(this long millisecondsSinceEpoch)
        {
            var dateTime = Epoch + TimeSpan.FromMilliseconds(millisecondsSinceEpoch);

            return dateTime.ToLocalTime().DateTime;
        }

        public static DateTime ToDateTime(this int secondsSinceEpoch)
        {
            var dateTime = Epoch + TimeSpan.FromSeconds(secondsSinceEpoch);

            return dateTime.ToLocalTime().DateTime;
        }

        public static CalendarEvent ToCalendarEvent(this Item item)
        {
            var staff = string.IsNullOrEmpty(item.StaffName) ?
                string.Empty :
                $" ({item.StaffName?.Split(' ')[0]})";

            var summary = $"{item.Title}{staff}";

            return new CalendarEvent
            {
                Uid = item.Id,
                Summary = summary,
                Location = item.Location.FirstOrDefault(),
                Start = new CalDateTime(item.Start, "Europe/Copenhagen"),
                End = new CalDateTime(item.End, "Europe/Copenhagen"),
                IsAllDay = item.AllDay
            };
        }

        public static Calendar ToCalendar(this IEnumerable<Item> items)
        {
            var calendar = new Calendar();

            foreach (var item in items.Select(ToCalendarEvent))
            {
                calendar.Events.Add(item);
            }

            return calendar;
        }

        public static string Serialize(this Calendar calendar)
        {
            var serializer = new CalendarSerializer(new SerializationContext());

            return serializer.SerializeToString(calendar);
        }
    }
}
