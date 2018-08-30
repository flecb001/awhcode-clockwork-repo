using System;
using Microsoft.AspNetCore.Mvc;
using Clockwork.API.Models;

namespace Clockwork.API.Controllers
{
    [Route("api/[controller]")]
    public class TimeZonesController : Controller
    {
        // GET api/timezones
        [HttpGet]
        public IActionResult TimeZones()
        {
            return Ok(TimeZoneInfo.GetSystemTimeZones());
        }
    }
}
