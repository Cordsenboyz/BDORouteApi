namespace BDORouteApi.Model
{
    public class MobinstancePull
    {
        public int PullId { get; set; }
        public Pull Pull { get; set; } = new();
        public int MobinstanceId { get; set; }
        public Mobinstance Mobinstance { get; set; } = new();
    }
}
