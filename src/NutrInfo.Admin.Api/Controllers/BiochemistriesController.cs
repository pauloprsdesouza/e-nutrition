using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrinfo.Admin.Domain.Biochemistries;
using NutrInfo.Admin.Contracts.Biochemistries;

namespace NutrInfo.Admin.Api.Controllers
{
    [Route("api/v1/biochemistries")]
    public class BiochemistriesController : Controller
    {
        private readonly IBiochemistryRepository _repository;

        public BiochemistriesController(IBiochemistryRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Estimates a Weight and Height from a patient
        /// </summary>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(GetBiochemistryReponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> List()
        {
            var biochemistries = await _repository.FindAll();
            return Ok(new GetBiochemistryReponse()
            {
                Biochemistries = biochemistries.Select(x => x.MapToResponse())
            });
        }
    }
}
