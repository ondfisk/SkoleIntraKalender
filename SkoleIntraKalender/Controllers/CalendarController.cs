using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SkoleIntraKalender.Models;
using System;
using System.Threading.Tasks;

namespace SkoleIntraKalender.Controllers
{
    [Produces("text/calendar")]
    [Route("api/[controller]")]
    public class CalendarController : Controller
    {
        private readonly CalendarOptions _options;
        private readonly ICalendarService _service;

        public CalendarController(IOptions<CalendarOptions> options, ICalendarService service)
        {
            _options = options.Value;
            _service = service;
        }

        // GET api/calendar
        [HttpGet("{password}")]
        public async Task<IActionResult> Get(string password)
        {
            if (!Guid.TryParse(password, out var p) || _options.Password != p)
            {
                return Unauthorized();
            }

            var items = await _service.GetItemsAsync();

            return Ok(items);
        }
    }
}
