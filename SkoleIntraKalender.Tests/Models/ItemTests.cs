namespace SkoleIntraKalender.Tests.Models;

public class ItemTests
{
    [Fact]
    public void Equals_given_same_properties_returns_true()
    {
        var a = new Item
        {
            Id = "1",
            Title = "title",
            Location = new[] { "location" },
            StaffName = "staff",
            Start = DateTime.Parse("2017-11-30 08:00:00"),
            End = DateTime.Parse("2017-11-30 08:30:00"),
            AllDay = false
        };

        var b = new Item
        {
            Id = "1",
            Title = "title",
            Location = new[] { "location" },
            StaffName = "staff",
            Start = DateTime.Parse("2017-11-30 08:00:00"),
            End = DateTime.Parse("2017-11-30 08:30:00"),
            AllDay = false
        };

        Assert.Equal(a, b);
    }

    [Fact]
    public void Equals_given_different_ids_returns_false()
    {
        var a = new Item
        {
            Id = "1",
            Title = "title",
            Location = new[] { "location" },
            StaffName = "staff",
            Start = DateTime.Parse("2017-11-30 08:00:00"),
            End = DateTime.Parse("2017-11-30 08:30:00"),
            AllDay = false
        };

        var b = new Item
        {
            Id = "2",
            Title = "title",
            Location = new[] { "location" },
            StaffName = "staff",
            Start = DateTime.Parse("2017-11-30 08:00:00"),
            End = DateTime.Parse("2017-11-30 08:30:00"),
            AllDay = false
        };

        Assert.NotEqual(a, b);
    }

    [Fact]
    public void Equals_given_different_titles_returns_false()
    {
        var a = new Item
        {
            Id = "1",
            Title = "title",
            Location = new[] { "location" },
            StaffName = "staff",
            Start = DateTime.Parse("2017-11-30 08:00:00"),
            End = DateTime.Parse("2017-11-30 08:30:00"),
            AllDay = false
        };

        var b = new Item
        {
            Id = "1",
            Title = "title2",
            Location = new[] { "location" },
            StaffName = "staff",
            Start = DateTime.Parse("2017-11-30 08:00:00"),
            End = DateTime.Parse("2017-11-30 08:30:00"),
            AllDay = false
        };

        Assert.NotEqual(a, b);
    }

    [Fact]
    public void Equals_given_locations_returns_false()
    {
        var a = new Item
        {
            Id = "1",
            Title = "title",
            Location = new[] { "location" },
            StaffName = "staff",
            Start = DateTime.Parse("2017-11-30 08:00:00"),
            End = DateTime.Parse("2017-11-30 08:30:00"),
            AllDay = false
        };

        var b = new Item
        {
            Id = "1",
            Title = "title",
            Location = new[] { "other" },
            StaffName = "staff",
            Start = DateTime.Parse("2017-11-30 08:00:00"),
            End = DateTime.Parse("2017-11-30 08:30:00"),
            AllDay = false
        };

        Assert.NotEqual(a, b);
    }

    [Fact]
    public void Equals_given_different_staffNames_returns_false()
    {
        var a = new Item
        {
            Id = "1",
            Title = "title",
            Location = new[] { "location" },
            StaffName = "staff",
            Start = DateTime.Parse("2017-11-30 08:00:00"),
            End = DateTime.Parse("2017-11-30 08:30:00"),
            AllDay = false
        };

        var b = new Item
        {
            Id = "1",
            Title = "title",
            Location = new[] { "location" },
            StaffName = "staff2",
            Start = DateTime.Parse("2017-11-30 08:00:00"),
            End = DateTime.Parse("2017-11-30 08:30:00"),
            AllDay = false
        };

        Assert.NotEqual(a, b);
    }

    [Fact]
    public void Equals_given_different_start_returns_false()
    {
        var a = new Item
        {
            Id = "1",
            Title = "title",
            Location = new[] { "location" },
            StaffName = "staff",
            Start = DateTime.Parse("2017-11-30 08:00:00"),
            End = DateTime.Parse("2017-11-30 08:30:00"),
            AllDay = false
        };

        var b = new Item
        {
            Id = "1",
            Title = "title",
            Location = new[] { "location" },
            StaffName = "staff",
            Start = DateTime.Parse("2017-11-30 08:30:00"),
            End = DateTime.Parse("2017-11-30 08:30:00"),
            AllDay = false
        };

        Assert.NotEqual(a, b);
    }

    [Fact]
    public void Equals_given_different_ends_returns_false()
    {
        var a = new Item
        {
            Id = "1",
            Title = "title",
            Location = new[] { "location" },
            StaffName = "staff",
            Start = DateTime.Parse("2017-11-30 08:00:00"),
            End = DateTime.Parse("2017-11-30 08:30:00"),
            AllDay = false
        };

        var b = new Item
        {
            Id = "1",
            Title = "title",
            Location = new[] { "location" },
            StaffName = "staff",
            Start = DateTime.Parse("2017-11-30 08:00:00"),
            End = DateTime.Parse("2017-11-30 08:45:00"),
            AllDay = false
        };

        Assert.NotEqual(a, b);
    }

    [Fact]
    public void Equals_given_different_allDays_returns_false()
    {
        var a = new Item
        {
            Id = "1",
            Title = "title",
            Location = new[] { "location" },
            StaffName = "staff",
            Start = DateTime.Parse("2017-11-30 08:00:00"),
            End = DateTime.Parse("2017-11-30 08:30:00"),
            AllDay = false
        };

        var b = new Item
        {
            Id = "1",
            Title = "title",
            Location = new[] { "location" },
            StaffName = "staff",
            Start = DateTime.Parse("2017-11-30 08:00:00"),
            End = DateTime.Parse("2017-11-30 08:30:00"),
            AllDay = true
        };

        Assert.NotEqual(a, b);
    }
}
