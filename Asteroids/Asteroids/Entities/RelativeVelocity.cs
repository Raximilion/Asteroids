using Newtonsoft.Json;

namespace Asteroids.Entities
{
    public class RelativeVelocity
    {
        [JsonProperty("kilometers_per_hour")]
        public string Velocity { get; set; }
    }
}
