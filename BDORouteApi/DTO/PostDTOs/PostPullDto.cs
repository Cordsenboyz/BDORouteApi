namespace BDORouteApi.DTO
{
    public class PostPullDto
    {
        public int Id { get; set; }

        public List<DevPostMobinstanceDto> MobInstances { get; set; } = new();
    }
}
