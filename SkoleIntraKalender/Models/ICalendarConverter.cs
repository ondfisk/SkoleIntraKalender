using System.Collections.Generic;
using Ical.Net;
using Ical.Net.CalendarComponents;

namespace SkoleIntraKalender.Models
{
    public interface ICalendarConverter
    {
        IEnumerable<Item> GroupByTitleAndTime(IEnumerable<Item> items);
        IEnumerable<Item> GroupByTitleAndStaff(IEnumerable<Item> items);
        string Serialize(Calendar calendar);
        Calendar ConvertToCalendar(IEnumerable<Item> items);
        CalendarEvent ConvertToCalendarEvent(Item item);
    }
}