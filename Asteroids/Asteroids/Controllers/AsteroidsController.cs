using Asteroids.Entities;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Asteroids.Controllers
{
    public class AsteroidsController : Controller
    {
        static HttpClient client = new HttpClient();
        private readonly ILogger<AsteroidsController> _logger;
        const string BASE_URL = "https://api.nasa.gov/neo/rest/v1/feed?";
        const string API_KEY = "&api_key=zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb";
        public AsteroidsController(ILogger<AsteroidsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int number)
        {
            var model = GetAsteroids(number);
            return View();
        }

        private async Task<bool> GetAsteroids(int number)
        {
            NasaApiResult nearEarthObjects = null;
            var startDate = DateTime.Now;
            var endDate = startDate.AddDays(number);
            HttpResponseMessage response = await client.GetAsync($"{BASE_URL}start_date={startDate.ToString("yyyy-MM-dd")}&end_date={endDate.ToString("yyyy-MM-dd")}{API_KEY}");

            if (response.IsSuccessStatusCode)
            {
                nearEarthObjects = await response.Content.ReadAsAsync<NasaApiResult>();
            }

            return false;
        }

        
    }
}
