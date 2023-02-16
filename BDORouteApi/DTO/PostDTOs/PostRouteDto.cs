using Newtonsoft.Json;

namespace BDORouteApi.DTO
{
    public class PostRouteDto
    {
        public int Id { get; set; }

        [JsonProperty("CreatedById")]
        public string CreatedById { get; set; } = "";

        [JsonProperty("Name")]
        public string Name { get; set; } = "";

        [JsonProperty("Description")]
        public string Description { get; set; } = "";

        [JsonProperty("ClassName")]
        public string ClassName { get; set; } = "";

        public List<PostPullDto> Pulls { get; set; } = new();
    }
}
