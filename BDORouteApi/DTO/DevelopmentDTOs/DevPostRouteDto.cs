using Newtonsoft.Json;

namespace BDORouteApi.DTO
{
    public class DevPostRouteDto
    { 

        [JsonProperty("Name")]
        public string Name { get; set; } = "";

        [JsonProperty("Description")]
        public string Description { get; set; } = "";

        [JsonProperty("ClassName")]
        public string ClassName { get; set; } = "";

        public List<DevPostPullDto> Pulls { get; set; } = new();
    }
}
