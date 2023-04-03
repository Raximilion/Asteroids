using Newtonsoft.Json;

namespace Asteroids.Entities
{
    public class Kilometers
    {
        [JsonProperty("estimated_diameter_min")]
        public double Min { get; set; }
        [JsonProperty("estimated_diameter_max")]
        public double Max { get; set; }
    }
}
