using Microsoft.AspNetCore.Mvc;
using System;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<string> Get()
        {
            return Summaries;
        }
        [HttpPost]
        public IActionResult Add(string name)
        {
            Summaries.Add(name);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("no");
            Summaries[index] = name;
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("no");
            Summaries.RemoveAt(index);
            return Ok();
        }
        [HttpGet("{index}")]
        public string GetName(int index)
        {
            if (index < 0 || index >= Summaries.Count)
                return "no";
            return Summaries[index];
        }
        [HttpGet("find-by-name")]
        public int Count(string name)
        {
            int count = 0;
            for (int i = 0; i < Summaries.Count; i++)
            {
                if (Summaries[i] == name)
                    count++;
            }
            return count;
        }
        [HttpGet("lol")]
        public IActionResult GetAll(int? sortStrategy)
        {
            if (sortStrategy == null)
                return Ok(Summaries);
            if (sortStrategy == 1)
            {
                IEnumerable<string> query =
                    from i in Summaries orderby i select i;
                return Ok(query);
            }
            if (sortStrategy == -1)
            {
                IEnumerable<string> query =
                    from i in Summaries
                    orderby i
                    descending
                    select i;
                return Ok(query);
            }
            return BadRequest("lol");
        }
    }
}