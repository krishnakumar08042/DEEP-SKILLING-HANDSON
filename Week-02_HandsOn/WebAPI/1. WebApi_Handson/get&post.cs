using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private static List<string> values = new() { "value1", "value2" };

        [HttpGet]
        public IEnumerable<string> Get() => values;

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            values.Add(value);
            return Ok(values);
        }
    }
}
