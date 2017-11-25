using System;
using Xunit;
using SkoleIntraKalender.Models;

namespace SkoleIntraKalender.Tests.Models
{
    public class ExtensionsTests
    {
        [Fact]
        public void ToDateTime()
        {
            var millisecondsSinceEpoch = 1511248200000;

            var output = millisecondsSinceEpoch.ToDateTime();

            Assert.Equal(DateTime.Parse("2017-11-21T08:10:00.0000000"), output);
        }

        [Fact]
        public void ToMillisecondsSinceEpoch()
        {
            var dateTime = DateTime.Parse("2017-11-21T08:10:00.0000000");

            var output = dateTime.ToMillisecondsSinceEpoch();

            Assert.Equal(1511248200000, output);
        }

        [Fact]
        public void ToSecondsSinceEpoch()
        {
            var dateTime = DateTime.Parse("2017-11-21T08:10:00.0000000");

            var output = dateTime.ToSecondsSinceEpoch();

            Assert.Equal(1511248200, output);
        }

        [Fact]
        public void ToDateTime_given_seconds()
        {
            var sSinceEpoch = 1511248200;

            var output = sSinceEpoch.ToDateTime();

            Assert.Equal(DateTime.Parse("2017-11-21T08:10:00.0000000"), output);
        }

        [Fact]
        public void ToCalendarEvent()
        {
            var start = DateTime.Parse("2000-01-13 12:00:00");
            var end = DateTime.Parse("2000-01-13 13:00:00");

            var item = new Item
            {
                Id = "id",
                Title = "title",
                StaffName = "firstName lastName",
                Location = new[] { "location" },
                Start = start,
                End = end,
                AllDay = false
            };

            var calendarEvent = item.ToCalendarEvent();

            Assert.Equal("id", calendarEvent.Uid);
            Assert.Equal("title (firstName)", calendarEvent.Summary);
            Assert.Equal("location", calendarEvent.Location);
            Assert.Equal(start, calendarEvent.DtStart.Value);
            Assert.Equal("Europe/Copenhagen", calendarEvent.DtStart.TimeZoneName);
            Assert.Equal(end, calendarEvent.DtEnd.Value);
            Assert.Equal("Europe/Copenhagen", calendarEvent.DtEnd.TimeZoneName);
        }
    }
}
