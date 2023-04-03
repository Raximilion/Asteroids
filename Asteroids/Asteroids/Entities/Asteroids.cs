using Newtonsoft.Json;

namespace Asteroids.Entities
{
    public class Asteroids
    {
        public string Name { get; set; }

        [JsonProperty("estimated_diameter")]
        public EstimatedDiameter EstimatedDiameter { get; set; }

        [JsonProperty("close_approach_data")]
        public List<CloseApproachDatum> CloseApproachData { get; set; }
    }
}
