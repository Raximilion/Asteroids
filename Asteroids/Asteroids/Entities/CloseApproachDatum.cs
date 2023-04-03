using Newtonsoft.Json;

namespace Asteroids.Entities
{
    public class CloseApproachDatum
    {
        [JsonProperty("close_approach_date")]
        public string Date { get; set; }
        [JsonProperty("relative_velocity")]
        public RelativeVelocity RelativeVelocity { get; set; }
        [JsonProperty("orbiting_body")]
        public string OrbitingBody { get; set; }
    }
}
