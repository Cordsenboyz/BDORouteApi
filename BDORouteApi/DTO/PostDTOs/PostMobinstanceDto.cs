namespace BDORouteApi.DTO
{
    public class PostMobinstanceDto
    {
        public int Id { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public PostMobDto Mob { get; set; } = new();
    }
}
