namespace SkoleIntraKalender.Models;

public interface ICalendarService : IDisposable
{
    Task<IReadOnlyCollection<Item>> GetItemsAsync();
}
