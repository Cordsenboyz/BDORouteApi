using BDORouteApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BDORouteApi
{
    public class BDORouteApiDBContext : DbContext
    {
        public readonly IConfiguration _configuration;

        public DbSet<Model.Route> Routes { get; set; }
        public DbSet<Pull> Pulls { get; set; }
        public DbSet<Mob> Mobs { get; set; }    
        public DbSet<MobType> MobTypes { get; set; }
        public DbSet<Mobinstance> Mobinstances { get; set; }

        public BDORouteApiDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlServer(_configuration.GetConnectionString("LocalDb"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
