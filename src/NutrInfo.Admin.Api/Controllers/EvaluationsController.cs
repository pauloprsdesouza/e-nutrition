using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.Patients;
using NutrInfo.Admin.Api.Models;
using NutrInfo.Admin.Api.Models.Evaluations;
using NutrInfo.Admin.Application.Evaluations;

namespace NutrInfo.Admin.Api.Controllers
{
    [Route("api/v1/evaluations")]
    public class EvaluationsController : Controller
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly IPatientRepository _patientRepository;

        public EvaluationsController(IEvaluationRepository evaluationRepository, IPatientRepository patientRepository)
        {
            _evaluationRepository = evaluationRepository;
            _patientRepository = patientRepository;
        }

        /// <summary>
        /// Find a registered Evaluation
        /// </summary>
        /// <param name="evaluationId"></param>
        [HttpGet, Route("{evaluationId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EvaluationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] int evaluationId)
        {
            var evaluationSearch = new EvaluationSearch(_evaluationRepository);
            var evaluation = await evaluationSearch.Find(evaluationId);

            if (evaluationSearch.EvaluationNotFound)
            {
                return UnprocessableEntity(new ResponseError("EVALUATION_NOT_FOUND"));
            }

            return Ok(evaluation.MapToResponse());
        }

        /// <summary>
        /// Create a new Evaluation
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EvaluationResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create([FromBody] PostEvaluationRequest request)
        {
            var nutritionistId = int.Parse(HttpContext.User.Identity.Name);

            var evaluationRegistration = new EvaluationRegistration(_evaluationRepository, _patientRepository);
            var evaluation = await evaluationRegistration.Register(nutritionistId, request.ToEvaluation());

            if (evaluationRegistration.PatientNotFound)
            {
                return UnprocessableEntity(new ResponseError("PATIENT_NOT_FOUND"));
            }

            return Created($"api/v1/evaluations/{evaluation.Id}", evaluation.MapToResponse());
        }

        /// <summary>
        /// Update a registered evaluation with Initial data
        /// </summary>
        /// <param name="evaluationId"></param>
        /// <param name="request"></param>
        [HttpPut, Route("{evaluationId}/initial")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EvaluationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> InitialEvaluation([FromRoute] int evaluationId, [FromBody] PutInitialEvaluationRequest request)
        {
            var evaluationRegistration = new InitialEvaluationRegistration(_evaluationRepository);
            var evaluation = await evaluationRegistration.Register(evaluationId, request);

            if (evaluationRegistration.EvaluationNotFound)
            {
                return UnprocessableEntity(new ResponseError("EVALUATION_NOT_FOUND"));
            }

            return Ok(evaluation.MapToResponse());
        }

        /// <summary>
        /// Udpdate a registered evaluation with NRS2022 data
        /// </summary>
        /// <param name="evaluationId"></param>
        /// <param name="request"></param>
        [HttpPut, Route("{evaluationId}/NRS")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EvaluationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> NRSEvaluation([FromRoute] int evaluationId, [FromBody] PutNRSEvaluationRequest request)
        {
            var nrsEvaluationRegistration = new NRSEvaluationRegistration(_evaluationRepository);
            var evaluation = await nrsEvaluationRegistration.Register(evaluationId, request);

            if (nrsEvaluationRegistration.EvaluationNotFound)
            {
                return UnprocessableEntity(new ResponseError("EVALUATION_NOT_FOUND"));
            }

            return Ok(evaluation.MapToResponse());
        }
    }
}
