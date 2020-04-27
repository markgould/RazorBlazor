using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Shared;

namespace WebApplication1.Server.Pages.Weather
{
    public class IndexPageModel : PageModel
    {
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnGetWeatherDataAsync()
        {
            var rng = new Random();
            return new JsonResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray());
        }

        public async Task<IActionResult> OnPostWeatherDataAsync([FromBody] IEnumerable<WeatherForecast> forecasts)
        {
            return new JsonResult(new { Result = "ok", Forecasts = forecasts.Count()});
        }
    }
}
