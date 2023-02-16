using BDORouteApi.DTO;
using Microsoft.AspNetCore.Mvc;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Mapster;
using BDORouteApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BDORouteApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RoutesController : ControllerBase
    {
        FirebaseClient firebaseClient = new("https://bdomaproute-default-rtdb.europe-west1.firebasedatabase.app/");
        private readonly ILogger<RoutesController> _logger;
        private readonly BDORouteApiDBContext _context;

        public RoutesController(ILogger<RoutesController> logger, BDORouteApiDBContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet(Name = "GetRoute")]
        public ActionResult Get(string discordID, string accessToken, int RouteId)
        {
            var result = _context.Routes
                .Where(r => r.Id == RouteId)
                .Include(r => r.Pulls)
                .ThenInclude(p => p.MobInstances)
                .ThenInclude(mi => mi.Mob)
                .ThenInclude(m => m.MobType)
                .Select(a => a.Adapt<DevPostRouteDto>());

            if (result is null) return NotFound($"A route with the id: {RouteId} was not found");

            return Ok(result);
        }

        [HttpGet(Name = "GetAllRoutes")]
        public async Task<ActionResult> GetAll(string discordID, string accessToken)
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<Model.Route, GetAllRoutesDto>()
                .Map(dest => dest.Pulls, src => src.Pulls.Count);

            var result = await _context.Routes
                .Include(r => r.Pulls)
                .Select(a => a.Adapt<GetAllRoutesDto>(config)).ToListAsync();
            return Ok(result);
        }

        [HttpPost(Name = "PostRoute")]
        public async Task<ActionResult> Post(string discordID, string accessToken, [FromBody] DevPostRouteDto postRouteDto)
        {
            List<Mobinstance?> mobInstancesInDb = postRouteDto.Pulls.SelectMany(pull =>
                 pull.MobInstances.Select(mobInsPull =>
                     _context.Mobinstances.FirstOrDefault(ins =>
                         ins.Id == mobInsPull.Id))).ToList();

            if (mobInstancesInDb.Any(mobInstance => mobInstance is null))
                return BadRequest("Can't create a route with that information");

            Model.Route route = postRouteDto.Adapt<Model.Route>();
            foreach(var pull in route.Pulls)
            {
                pull.MobInstances = pull.MobInstances.Select(mi => mobInstancesInDb.First(miidb => miidb!.Id == mi.Id)).ToList();
            }
            route.CreatedById = discordID;
            await _context.Routes.AddAsync(route);
            await _context.SaveChangesAsync();
            return Ok("The Route was successfully created");
        }

        [HttpPut(Name = "PutRoute")]
        public async Task<ActionResult> Put(int Id, string discordID, string accessToken, [FromBody] DevPostRouteDto devpostRouteDto)
        {
            Model.Route? route = _context.Routes.FirstOrDefaultAsync(r => r.Id == Id && r.CreatedById == discordID).Result;
            if (route == null) return NotFound($"A route with the id: {Id} could not be found");

            devpostRouteDto.Adapt(route);

            _context.Update(route);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}