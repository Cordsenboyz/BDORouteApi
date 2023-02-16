using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BDORouteApi.Model
{
    public class Mobinstance
    {
        [Key]
        [JsonProperty("Id")]
        public int Id { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        [JsonProperty("Mob")]
        public Mob Mob { get; set; } = new();

        public List<Pull> Pulls { get; set; } = new();
    }
}
