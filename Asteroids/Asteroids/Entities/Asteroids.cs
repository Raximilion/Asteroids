using Newtonsoft.Json;

namespace Asteroids.Entities
{
    public class AsteroidsEntity
    {
        public string Name { get; set; }

        [JsonProperty("estimated_diameter")]
        public EstimatedDiameter EstimatedDiameter { get; set; }

        [JsonProperty("close_approach_data")]
        public  CloseApproachDatum CloseApproachData { get; set; }
    }
}
