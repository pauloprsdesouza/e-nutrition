using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutrInfo.Admin.Api.Features.Evaluations;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Serialization.Evaluations;
using NutrInfo.Admin.Api.Models.Evaluations;

namespace NutrInfo.Admin.Api.Controllers
{
    [Route("evaluations")]
    public class EvaluationsController : Controller
    {
        public readonly ApiDbContext _dbContext;

        public EvaluationsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostEvaluationRequest evaluationRequest)
        {
            var createEvaluation = new CreateEvaluation(_dbContext);
            var evaluation = evaluationRequest.ToEvaluation();

            await createEvaluation.Register(evaluation);


            return Created("/evaluations/", evaluation.MapToResponse());
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            var evaluationSearch = new EvaluationSearch(_dbContext);
            var evaluation = await evaluationSearch.Find(id);

            if (evaluationSearch.EvaluationNotFound)
            {
                return NotFound();
            }

            return Ok(evaluation.MapToResponse());
        }

        [HttpGet, Route("{patientId}")]
        public async Task<IActionResult> LatestEvaluation([FromRoute] int patientId)
        {
            var evaluationSearch = new EvaluationSearchByPatient(_dbContext);
            var evaluation = await evaluationSearch.Find(patientId);

            if (evaluationSearch.EvaluationNotFound)
            {
                return NotFound();
            }

            return Ok(evaluation.MapToResponse());
        }
    }
}
