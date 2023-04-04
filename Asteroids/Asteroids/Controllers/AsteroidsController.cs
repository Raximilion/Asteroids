using Asteroids.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Xml.Linq;

namespace Asteroids.Controllers
{
    public class AsteroidsController : Controller
    {
        private readonly ILogger<AsteroidsController> _logger;
        const string BASE_URL = "https://api.nasa.gov/neo/rest/v1/feed?";
        const string API_KEY = "&api_key=zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb";
        public AsteroidsController(ILogger<AsteroidsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int number)
        {
            var data = GetAsteroids(number-1).Result;
            return View(model: data);
        }

        private async Task<List<AsteroidsEntity>> GetAsteroids(int number)
        {
            List<AsteroidsEntity> asteroidsList = new();
            var startDate = DateTime.Now;
            var endDate = startDate.AddDays(number);
            var url = $"{BASE_URL}start_date={startDate.ToString("yyyy-MM-dd")}&end_date={endDate.ToString("yyyy-MM-dd")}{API_KEY}";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                var responseClient = client.GetAsync(url).Result;
                var res = responseClient.Content.ReadAsStringAsync().Result;
                dynamic r = JObject.Parse(res);

                //Los nombres con _ es porque vienen asi de la api de externos imagino que es una api hecha con pyton por que la nomenclatura es asi
                foreach (var item in r.near_earth_objects) 
                {
                    AsteroidsEntity asteroid = new();
                    asteroid.EstimatedDiameter = new();
                    asteroid.EstimatedDiameter.kilometers = new();
                    asteroid.CloseApproachData = new();
                    asteroid.CloseApproachData.RelativeVelocity = new();

                    asteroid.Name = item.First[0].name.Value;
                    asteroid.EstimatedDiameter.kilometers.Max = item.First[0].estimated_diameter.kilometers.estimated_diameter_max.Value;
                    asteroid.EstimatedDiameter.kilometers.Min = item.First[0].estimated_diameter.kilometers.estimated_diameter_min.Value;
                    asteroid.CloseApproachData.Date = item.First[0].close_approach_data[0].close_approach_date.Value;
                    asteroid.CloseApproachData.RelativeVelocity.Velocity = item.First[0].close_approach_data[0].relative_velocity.kilometers_per_hour.Value;
                    asteroid.CloseApproachData.OrbitingBody = item.First[0].close_approach_data[0].orbiting_body.Value;

                    asteroidsList.Add(asteroid);
                }
            }

            return asteroidsList;

        }

        
    }
}
