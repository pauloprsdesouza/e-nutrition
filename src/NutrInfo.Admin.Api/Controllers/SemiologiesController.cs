using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrinfo.Admin.Domain.Semiologies;
using NutrInfo.Admin.Contracts.Semiologies;

namespace NutrInfo.Admin.Api.Controllers
{
    [Route("api/v1/semiologies")]
    public class SemiologiesController : Controller
    {
        private readonly ISemiologyRepository _repository;

        public SemiologiesController(ISemiologyRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Estimates a Weight and Height from a patient
        /// </summary>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(GetSemiologyResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> List()
        {
            var semiologies = await _repository.FindAllGrouped();

            return Ok(new GetSemiologyResponse()
            {
                Semiologies = semiologies.Select(x => x.MapToResponse()).ToList()
            });
        }
    }
}
