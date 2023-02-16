using BDORouteApi.DTO;
using BDORouteApi.Model;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDORouteApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MobController : ControllerBase
    {
        private readonly ILogger<MobController> _logger;
        private readonly BDORouteApiDBContext _context;

        public MobController(ILogger<MobController> logger, BDORouteApiDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost(Name = "PostMob")]
        public async Task<ActionResult> Post([FromBody] PostMobDto postMobDto)
        {
            MobType? mobType = _context.MobTypes.FirstOrDefault(mt => mt.Name == postMobDto.MobType.Name);
            Mob mob = postMobDto.Adapt<Mob>();
            if (mobType is not null)
                mob.MobType = mobType;
            _context.Add(mob);
            await _context.SaveChangesAsync();
            return Ok(postMobDto);
        }

        [HttpGet(Name = "GetMob")]
        public ActionResult Get(string mobName)
        {
            return Ok(_context.Mobs.Include(mob => mob.MobType).FirstOrDefault(mob => mob.Name == mobName));
        }
    }
}
