using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrinfo.Admin.Domain.Limbs;
using NutrInfo.Admin.Contracts;
using NutrInfo.Admin.Contracts.AmputatedLimbs;

namespace NutrInfo.Admin.Api.Controllers
{
    [Route("api/v1/amputatedlimbs")]
    public class AmputatedLimbsController : Controller
    {
        private readonly ILimbRepository _repository;

        public AmputatedLimbsController(ILimbRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all registered amputated limbs
        /// </summary>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(GetAmputatedLimbResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> List()
        {
            var amputatedLimbs = await _repository.FindAll();

            return Ok(new GetAmputatedLimbResponse()
            {
                AmputatedLimbs = amputatedLimbs.Select(x => x.MapToResponse())
            });
        }
    }
}
