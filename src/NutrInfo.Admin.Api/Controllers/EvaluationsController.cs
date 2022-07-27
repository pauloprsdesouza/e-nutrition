using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutrInfo.Admin.Api.Features.Evaluations;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Models;
using NutrInfo.Admin.Api.Models.Evaluations;

namespace NutrInfo.Admin.Api.Controllers
{
    [Route("api/v1/evaluations")]
    public class EvaluationsController : Controller
    {
        public readonly ApiDbContext _dbContext;

        public EvaluationsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EvaluationResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create([FromBody] PostEvaluationRequest evaluationRequest)
        {
            var evaluationRegistration = new EvaluationRegistration(_dbContext);
            var evaluation = evaluationRequest.ToEvaluation();
            evaluation.NutritionistId = int.Parse(HttpContext.User.Identity.Name);

            await evaluationRegistration.Register(evaluation);

            if (evaluationRegistration.PatientNotFound)
            {
                return UnprocessableEntity(new ResponseError("PATIENT_NOT_FOUND"));
            }

            return Created("api/v1/evaluations/", evaluation.MapToResponse());
        }

        [HttpGet, Route("{evaluationId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EvaluationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EstimateWeightAndHeight([FromRoute] int evaluationId, GetWeightHeightEstimationRequest weightHeightEstimationRequest)
        {
            var weightHeightEstimation = new WeightHeightEstimation(_dbContext);
            var evaluation = await weightHeightEstimation.Calculate(evaluationId, weightHeightEstimationRequest);

            if (weightHeightEstimation.PatientNotFound)
            {
                return NotFound(new ResponseError("PATIENT_NOT_FOUND"));
            }

            if (weightHeightEstimation.EvaluationNotFound)
            {
                return NotFound(new ResponseError("EVALUATION_NOT_FOUND"));
            }

            return Ok(evaluation.MapToResponse());
        }

        [HttpPut, Route("{evaluationId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EvaluationResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute] int evaluationId, [FromBody] PatchInitialEvaluationRequest weightHeightEstimationRequest)
        {
            return Ok();

        }
    }
}
