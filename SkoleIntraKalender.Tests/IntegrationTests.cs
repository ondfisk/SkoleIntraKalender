﻿
namespace SkoleIntraKalender.Tests;

public class IntegrationTests
{
    [Fact(Skip = "Integration test")]
    public async Task Get_new_sample()
    {
        var builder = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
          .AddEnvironmentVariables();

        var configuration = builder.Build();

        var options = new CalendarOptions();
        configuration.Bind("CalendarService", options);

        var calendarOptions = new Mock<IOptions<CalendarOptions>>();
        calendarOptions.Setup(o => o.Value).Returns(options);

        var handler = new AuthorizedHandler(calendarOptions.Object);

        var service = new CalendarService(calendarOptions.Object, handler);

        var items = await service.GetItemsAsync();

        var json = JsonSerializer.Serialize(items);

        File.WriteAllText($"../../../sample-{DateTime.UtcNow:yyyyMMddThhmmssZ}.json", json);
    }
}
