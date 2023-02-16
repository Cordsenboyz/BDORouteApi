using System.ComponentModel.DataAnnotations;

namespace BDORouteApi.DTO
{
    public class PostMobDto
    {
        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public bool IsElite { get; set; }

        public PostMobTypeDto MobType { get; set; } = new();

        public string TrashDropRange { get; set; } = "";
    }
}
