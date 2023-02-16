using Newtonsoft.Json;

namespace BDORouteApi.Model
{
    public class Pull
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        public List<Mobinstance> MobInstances { get; set; } = new();
    }
}
