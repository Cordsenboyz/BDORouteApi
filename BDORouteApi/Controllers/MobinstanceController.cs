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
    public class MobinstanceController : ControllerBase
    {
        private readonly ILogger<MobinstanceController> _logger;
        private readonly BDORouteApiDBContext _context;

        public MobinstanceController(ILogger<MobinstanceController> logger, BDORouteApiDBContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpPost(Name = "PostMobinstance")]
        public async Task<ActionResult> Post([FromBody] PostMobinstanceDto postMobinstanceDto)
        {
            Mob? mob = _context.Mobs.FirstOrDefault(m => m.Name == postMobinstanceDto.Mob.Name);
            Mobinstance mobinstance = postMobinstanceDto.Adapt<Mobinstance>();
            if (mob is not null)
                mobinstance.Mob = mob;
            _context.Add(mobinstance);
            await _context.SaveChangesAsync();
            return Ok(postMobinstanceDto);
        }

        [HttpGet(Name = "GetMobinstance")]
        public ActionResult Get(int id)
        {
            var result = _context.Mobinstances.Include(mt => mt.Mob.MobType).FirstOrDefault(m => m.Id == id);
            if (result is null) return NotFound($"A Mobinstance with the id: {id} was not found");

            return Ok(result.Adapt<DevPostMobinstanceDto>());
        }
    }
}
