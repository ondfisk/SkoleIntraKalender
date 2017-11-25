using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkoleIntraKalender.Models
{
    public interface ICalendarService : IDisposable
    {
        Task<IReadOnlyCollection<Item>> GetItemsAsync();
    }
}