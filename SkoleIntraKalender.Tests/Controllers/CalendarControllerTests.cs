using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using SkoleIntraKalender.Controllers;
using SkoleIntraKalender.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SkoleIntraKalender.Tests.Controllers
{
    public class CalendarControllerTests
    {
        [Fact]
        public async Task Get_given_not_a_guid_returns_Unauthorized()
        {
            var options = new Mock<IOptions<CalendarOptions>>();

            var controller = new CalendarController(options.Object, null);

            var result = await controller.Get("foo");

            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public async Task Get_given_wrong_guid_returns_Unauthorized()
        {
            var calendarOptions = new CalendarOptions
            {
                Password = Guid.Parse("3905fb0e4b7349219b9c13334ea94250")
            };
            var options = new Mock<IOptions<CalendarOptions>>();
            options.SetupGet(o => o.Value).Returns(calendarOptions);

            var controller = new CalendarController(options.Object, null);

            var result = await controller.Get("04a6c52fb35143799ef72f4f9a27d10c");

            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public async Task Get_given_right_guid_returns_Ok_with_items_from_service()
        {
            var calendarOptions = new CalendarOptions
            {
                Password = Guid.Parse("04a6c52fb35143799ef72f4f9a27d10c")
            };
            var options = new Mock<IOptions<CalendarOptions>>();
            options.SetupGet(o => o.Value).Returns(calendarOptions);

            var items = new Item[0];
            var service = new Mock<ICalendarService>();
            service.Setup(s => s.GetItemsAsync()).ReturnsAsync(items);

            var controller = new CalendarController(options.Object, service.Object);

            var result = await controller.Get("04a6c52fb35143799ef72f4f9a27d10c") as OkObjectResult;

            Assert.Equal(items, result.Value);
        }
    }
}
