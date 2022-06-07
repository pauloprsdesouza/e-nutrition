using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Serialization.AmputatedLimbs;
using NutrInfo.Admin.Api.Models.AmputatedLimbs;

namespace NutrInfo.Admin.Api.Controllers
{
    [Route("api/v1/amputatedlimbs")]
    public class AmputatedLimbsController : Controller
    {
        private readonly ApiDbContext _dbContext;

        public AmputatedLimbsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// List all registered amputated limbs
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(GetAmputatedLimbResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> List([FromQuery] GetAmputatedLimbQuery queryString)
        {
            var amputatedlimbs = await _dbContext.AmputatedLimbs
                                                .ToListAsync();

            return Ok(new GetAmputatedLimbResponse()
            {
                AmputatedLimbs = amputatedlimbs.Select(amputatedlimb => amputatedlimb.MapToResponse())
            });
        }
    }
}
