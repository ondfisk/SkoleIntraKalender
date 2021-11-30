namespace SkoleIntraKalender.Models;

public class CalendarService : ICalendarService
{
    private readonly CalendarOptions _options;
    private readonly HttpClient _client;

    public CalendarService(IOptions<CalendarOptions> options, DelegatingHandler handler)
    {
        _options = options.Value;

        _client = new HttpClient(handler)
        {
            BaseAddress = _options.BaseAddress
        };
        _client.DefaultRequestHeaders.Clear();
        _client.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    public async Task<IReadOnlyCollection<Item>> GetItemsAsync()
    {
        var start = DateTime.Today;
        var end = start.AddDays(5);
        var now = DateTime.Now;

        return await GetItemsAsync(start, end, now);
    }

    private async Task<IReadOnlyCollection<Item>> GetItemsAsync(DateTime start, DateTime end, DateTime now)
    {
        var s = start.ToSecondsSinceEpoch();
        var e = end.ToSecondsSinceEpoch();
        var n = now.ToMillisecondsSinceEpoch();

        var url = string.Format(_options.UrlFormatString, _options.ClassName, s, e, n);

        var response = await _client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Item[]>(json);
        }

        return new Item[0];
    }

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
                _client.Dispose();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            disposedValue = true;
        }
    }

    // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    // ~CalendarService() {
    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //   Dispose(false);
    // }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        Dispose(true);
        // TODO: uncomment the following line if the finalizer is overridden above.
        // GC.SuppressFinalize(this);
    }
    #endregion
}
