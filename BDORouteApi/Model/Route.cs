using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BDORouteApi.Model
{
    public class Route
    {
        [Key]
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("CreatedById")]
        public string CreatedById { get; set; } = "";

        [JsonProperty("Name")]
        public string Name { get; set; } = "";

        [JsonProperty("Description")]
        public string Description { get; set; } = "";

        [JsonProperty("ClassName")]
        public string ClassName { get; set; } = "";

        [JsonProperty("Pulls")]
        public List<Pull> Pulls { get; set; } = new();
    }
}
