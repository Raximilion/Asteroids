
using Newtonsoft.Json;

namespace Asteroids.Entities
{
    public class NasaApiResult
    {
        [JsonProperty("near_earth_objects")]
        NearEarthObjects NearEarthObjects { get; set; }
    }
}
