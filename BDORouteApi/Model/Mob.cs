using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BDORouteApi.Model
{
    public class Mob
    {
        [Key]
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; } = "";

        [JsonProperty("Description")]
        public string Description { get; set; } = "";

        [JsonProperty("IsElite")]
        public bool IsElite { get; set; }

        [JsonProperty("MobType")]
        public MobType MobType { get; set; } = new();

        [JsonProperty("TrashDropRange")]
        public string TrashDropRange { get; set; } = "";
    }
}
