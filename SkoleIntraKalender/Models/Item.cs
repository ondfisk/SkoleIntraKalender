namespace SkoleIntraKalender.Models;

public class Item : IEquatable<Item>
{
    public string Id { get; set; }
    public string Title { get; set; }

    private string[] _location;
    public string[] Location
    {
        get => _location ?? new string[0];
        set => _location = value;
    }

    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string StaffName { get; set; }
    public bool AllDay { get; set; }

    public bool Equals(Item other)
    {
        if (other == null)
        {
            return false;
        }

        var location = new HashSet<string>(Location);

        return
            Id == other.Id &&
            Title == other.Title &&
            location.SetEquals(other.Location) &&
            Start == other.Start &&
            End == other.End &&
            StaffName == other.StaffName &&
            AllDay == other.AllDay;
    }
}
