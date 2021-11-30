namespace SkoleIntraKalender.Tests.Models;

public class CalendarConverterTests
{
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

        var converter = new CalendarConverter();

        var calendarEvent = converter.ConvertToCalendarEvent(item);

        Assert.Equal("id", calendarEvent.Uid);
        Assert.Equal("title (firstName)", calendarEvent.Summary);
        Assert.Equal("location", calendarEvent.Location);
        Assert.Equal(start, calendarEvent.DtStart.Value);
        Assert.Equal("Europe/Copenhagen", calendarEvent.DtStart.TimeZoneName);
        Assert.Equal(end, calendarEvent.DtEnd.Value);
        Assert.Equal("Europe/Copenhagen", calendarEvent.DtEnd.TimeZoneName);
    }

    [Fact]
    public void GroupByTitleAndTime_given_two_classes_with_same_title_and_time_joins_them()
    {
        var items = new[]
        {
                new Item
                {
                    Id = "1",
                    Title = "Danish",
                    Location = new[] {"Room 4" },
                    StaffName = "Ole Olsen",
                    Start = DateTime.Parse("2017-11-30 08:00:00"),
                    End = DateTime.Parse("2017-11-30 08:45:00"),
                },
                new Item
                {
                    Id = "2",
                    Title = "Danish",
                    Location = new[] {"Room 55" },
                    StaffName = "Anders Andersen",
                    Start = DateTime.Parse("2017-11-30 08:00:00"),
                    End = DateTime.Parse("2017-11-30 08:45:00"),
                }
            };

        var expected = new[] {
                new Item
                {
                    Id = "1",
                    Title = "Danish",
                    Location = new[] {"Room 4" },
                    StaffName = "Anders/Ole",
                    Start = DateTime.Parse("2017-11-30 08:00:00"),
                    End = DateTime.Parse("2017-11-30 08:45:00"),
                }
            };

        var converter = new CalendarConverter();

        var group = converter.GroupByTitleAndTime(items);

        Assert.Equal(expected, group);
    }

    [Fact]
    public void GroupByTitleAndStaff_given_two_classes_with_same_title_and_staff_joins_them()
    {
        var items = new[]
        {
                new Item
                {
                    Id = "1",
                    Title = "Danish",
                    Location = new[] {"Room 4" },
                    StaffName = "Ole",
                    Start = DateTime.Parse("2017-11-29 08:00:00"),
                    End = DateTime.Parse("2017-11-29 08:45:00"),
                },
                new Item
                {
                    Id = "2",
                    Title = "Danish",
                    Location = new[] {"Room 4" },
                    StaffName = "Ole",
                    Start = DateTime.Parse("2017-11-29 09:00:00"),
                    End = DateTime.Parse("2017-11-29 09:45:00"),
                },
                new Item
                {
                    Id = "3",
                    Title = "Danish",
                    Location = new[] {"Room 4" },
                    StaffName = "Ole",
                    Start = DateTime.Parse("2017-11-30 08:00:00"),
                    End = DateTime.Parse("2017-11-30 08:45:00"),
                },
                new Item
                {
                    Id = "4",
                    Title = "Danish",
                    Location = new[] {"Room 4" },
                    StaffName = "Peter",
                    Start = DateTime.Parse("2017-11-30 09:00:00"),
                    End = DateTime.Parse("2017-11-30 09:45:00"),
                }
            };

        var expected = new[] {
                new Item
                {
                    Id = "1",
                    Title = "Danish",
                    Location = new[] {"Room 4" },
                    StaffName = "Ole",
                    Start = DateTime.Parse("2017-11-29 08:00:00"),
                    End = DateTime.Parse("2017-11-29 09:45:00"),
                },
                new Item
                {
                    Id = "3",
                    Title = "Danish",
                    Location = new[] {"Room 4" },
                    StaffName = "Ole",
                    Start = DateTime.Parse("2017-11-30 08:00:00"),
                    End = DateTime.Parse("2017-11-30 08:45:00"),
                },
                new Item
                {
                    Id = "4",
                    Title = "Danish",
                    Location = new[] {"Room 4" },
                    StaffName = "Peter",
                    Start = DateTime.Parse("2017-11-30 09:00:00"),
                    End = DateTime.Parse("2017-11-30 09:45:00"),
                }
            };

        var converter = new CalendarConverter();

        var group = converter.GroupByTitleAndStaff(items);

        Assert.Equal(expected, group);
    }
}
