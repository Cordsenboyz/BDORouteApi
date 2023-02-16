namespace BDORouteApi.DTO
{
    public record GetAllRoutesDto
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string ClassName { get; set; } = "";
        public int Pulls { get; set; }

    }
}