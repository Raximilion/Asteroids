using Newtonsoft.Json;

namespace Asteroids.Entities
{
    public class NearEarthObjects
    {
        [JsonProperty("yyyy-MM-dd")]
        List<Asteroids> Asteroids { get; set; }
    }
}
