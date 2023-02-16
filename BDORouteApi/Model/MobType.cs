using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BDORouteApi.Model
{
    public class MobType
    {
        [Key]
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; } = "";
    }
}
