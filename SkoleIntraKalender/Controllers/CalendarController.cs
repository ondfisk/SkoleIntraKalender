using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SkoleIntraKalender.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkoleIntraKalender.Controllers
{
    [Produces("text/calendar")]
    [Route("api/[controller]")]
    public class CalendarController : Controller
    {
        private readonly CalendarOptions _options;
        private readonly ICalendarService _service;
        private readonly ICalendarConverter _converter;

        public CalendarController(IOptions<CalendarOptions> options, 
            ICalendarService service,
            ICalendarConverter converter)
        {
            _options = options.Value;
            _service = service;
            _converter = converter;
        }

        // GET api/calendar
        [HttpGet("{password}")]
        public async Task<IActionResult> Get(string password)
        {
            if (!Guid.TryParse(password, out var p) || _options.Password != p)
            {
                return Unauthorized();
            }

            IEnumerable<Item> items = await _service.GetItemsAsync();

            items = _converter.GroupByTitleAndTime(items);
            items = _converter.GroupByTitleAndStaff(items);

            return Ok(items);
        }
    }
}
