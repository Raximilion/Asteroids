using Asteroids.Entities;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using System.Xml.Linq;

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
            ViewData["Json"] = GetAsteroids(number).Result;
            return View();
        }

        private async Task<string> GetAsteroids(int number)
        {
            NasaApiResult nearEarthObjects = null;
            var startDate = DateTime.Now;
            var endDate = startDate.AddDays(number);
            var url = $"{BASE_URL}start_date={startDate.ToString("yyyy-MM-dd")}&end_date={endDate.ToString("yyyy-MM-dd")}{API_KEY}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) 
                        return string.Empty;

                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        return responseBody;
                    }
                }
            }

            return string.Empty;




            //HttpResponseMessage response = await client.GetAsync($"{BASE_URL}start_date={startDate.ToString("yyyy-MM-dd")}&end_date={endDate.ToString("yyyy-MM-dd")}{API_KEY}");

            //if (response.IsSuccessStatusCode)
            //{
            //    var json = await response.Content.ReadAsStringAsync();
            //    var test = System.Text.Json.JsonSerializer.Deserialize<List<NasaApiResult>>(json);
            //    return false;
            //}
            //else
            //{
            //    return false;
            //}

        }

        
    }
}
