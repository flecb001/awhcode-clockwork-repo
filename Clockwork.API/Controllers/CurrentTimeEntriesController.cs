using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Clockwork.API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Clockwork.API.Controllers
{
    [Route("api/[controller]")]
    public class CurrentTimeEntriesController : Controller
    {
        // GET api/currenttimeentries
        [HttpGet]
        public IActionResult Get(int current, int rowCount, string searchPhrase)
        {
            JObject response;

            using (var db = new ClockworkContext())
            {
                var allEntriesArray = (from entry in db.CurrentTimeQueries
                    orderby entry.CurrentTimeQueryId descending
                    select entry);

                var entriesArray = allEntriesArray.Skip((current-1) * rowCount)
                    .Take(rowCount)
                    .ToArray();
                Console.WriteLine("{0} records in the database", entriesArray.Length);

                response =
                    new JObject(
                            new JObject(
                                new JProperty("current", current),
                                new JProperty("rowCount", -1),
                                new JProperty("total", allEntriesArray.Count()),
                                new JProperty("rows", JToken.FromObject(entriesArray))));
            }

            return Ok(response);
        }
    }
}
