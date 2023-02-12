using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrinfo.Admin.Domain.ClinicalChanges;
using NutrInfo.Admin.Contracts.ClinicalChanges;

namespace NutrInfo.Admin.Api.Controllers
{
    [Route("api/v1/clinicalChanges")]
    public class ClinicalChangesController : Controller
    {
        private readonly IClinicalChangeRepository _repository;

        public ClinicalChangesController(IClinicalChangeRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Estimates a Weight and Height from a patient
        /// </summary>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(GetClinicalChangeResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> List()
        {
            var clinicalChanges = await _repository.FindAll();
            return Ok(new GetClinicalChangeResponse()
            {
                ClinicalChanges = clinicalChanges.Select(x => x.MapToResponse())
            });
        }
    }
}
