using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrinfo.Admin.Domain.AmputatedLimbs;
using Nutrinfo.Admin.Domain.AsciteDegrees;
using Nutrinfo.Admin.Domain.Ascites;
using Nutrinfo.Admin.Domain.CircumferencePercentils;
using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.Patients;
using NutrInfo.Admin.Application.Evaluations;
using NutrInfo.Admin.Contracts;
using NutrInfo.Admin.Contracts.Evaluations;
using NutrInfo.Admin.Contracts.Evaluations.Anthropometry;
using NutrInfo.Admin.Contracts.Evaluations.Diagnosis;
using NutrInfo.Admin.Contracts.Evaluations.Initial;
using NutrInfo.Admin.Contracts.Evaluations.NRS2002;

namespace NutrInfo.Admin.Api.Controllers
{
    [Route("api/v1/evaluations")]
    public class EvaluationsController : Controller
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IAmputatedLimbRepository _amputatedLimbRepository;
        private readonly IAsciteRepository _asciteRepository;
        private readonly IAsciteDegreeRepository _asciteDegreeRepository;
        private readonly IArmCircumferencePercentilRepository _armPercentil;

        public EvaluationsController(IEvaluationRepository evaluationRepository, IPatientRepository patientRepository, IAmputatedLimbRepository amputatedLimbRepository, IAsciteRepository asciteRepository, IAsciteDegreeRepository asciteDegreeRepository, IArmCircumferencePercentilRepository armPercentil)
        {
            _evaluationRepository = evaluationRepository;
            _patientRepository = patientRepository;
            _amputatedLimbRepository = amputatedLimbRepository;
            _asciteRepository = asciteRepository;
            _asciteDegreeRepository = asciteDegreeRepository;
            _armPercentil = armPercentil;
        }

        /// <summary>
        /// Find a registered Evaluations from Nutritionist
        /// </summary>
        [HttpGet, Route("monitoring")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EvaluationResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> MonitoringByLoggedNutritionist()
        {
            var nutritionistId = int.Parse(HttpContext.User.Identity.Name);

            var evaluations = await _evaluationRepository.FindAllMonitoringByNutritionist(nutritionistId);

            return Ok(new GetEvaluationResponse()
            {
                Evaluations = evaluations.Select(x => x.MapToResponse())
            });
        }

        /// <summary>
        /// Find a registered Evaluations from Nutritionist
        /// </summary>
        [HttpGet, Route("monitoring/{nutritionistId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EvaluationResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> MonitoringByNutritionist([FromRoute] int nutritionistId)
        {
            var evaluations = await _evaluationRepository.FindAllMonitoringByNutritionist(nutritionistId);

            return Ok(new GetEvaluationResponse()
            {
                Evaluations = evaluations.Select(x => x.MapToResponse())
            });
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

            return Created($"api/v1/evaluations", evaluation.MapToResponse());
        }

        /// <summary>
        /// Update a registered evaluation with Initial data
        /// </summary>
        /// <param name="evaluationId"></param>
        /// <param name="request"></param>
        [HttpPut, Route("{evaluationId}/initial")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(InitialEvaluationMapResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> InitialEvaluation([FromRoute] int evaluationId, [FromBody] PutInitialEvaluationRequest request)
        {
            var evaluationRegistration = new InitialEvaluationRegistration(_evaluationRepository, _amputatedLimbRepository, _asciteRepository, _asciteDegreeRepository);
            var evaluation = await evaluationRegistration.Register(evaluationId, request);

            if (evaluationRegistration.EvaluationNotFound)
            {
                return UnprocessableEntity(new ResponseError("EVALUATION_NOT_FOUND"));
            }

            return Ok(evaluation.MapToInitialResponse());
        }

        /// <summary>
        /// Udpdate a registered evaluation with NRS2022 data
        /// </summary>
        /// <param name="evaluationId"></param>
        /// <param name="request"></param>
        [HttpPut, Route("{evaluationId}/nrs")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(NRSEvaluationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> NRSEvaluation([FromRoute] int evaluationId, [FromBody] PutNRSEvaluationRequest request)
        {
            var nrsEvaluationRegistration = new NRSEvaluationRegistration(_evaluationRepository);
            var evaluation = await nrsEvaluationRegistration.Register(evaluationId, request);

            if (nrsEvaluationRegistration.EvaluationNotFound)
            {
                return NotFound(new ResponseError("EVALUATION_NOT_FOUND"));
            }

            if (nrsEvaluationRegistration.ValidationErros.Any())
            {
                return UnprocessableEntity(new ResponseError(nrsEvaluationRegistration.ValidationErros));
            }

            return Ok(evaluation.MapToNRSResponse());
        }

        /// <summary>
        /// Udpdate a registered evaluation with NRS2022 data
        /// </summary>
        /// <param name="evaluationId"></param>
        /// <param name="request"></param>
        [HttpPut, Route("{evaluationId}/anthropometry")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(AnthropometryEvaluationMapResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> AnthropometryEvaluation([FromRoute] int evaluationId, [FromBody] PutAnthropometryEvaluationRequest request)
        {
            var anthropometryEvaluationRegistration = new AnthropometryEvaluationRegistration(_evaluationRepository);
            var evaluation = await anthropometryEvaluationRegistration.Register(evaluationId, request);

            if (anthropometryEvaluationRegistration.EvaluationNotFound)
            {
                return UnprocessableEntity(new ResponseError("EVALUATION_NOT_FOUND"));
            }

            return Ok(evaluation.MapToAnthropometryResponse());
        }

        /// <summary>
        /// Generate a diagnosis from a registered evaluation
        /// </summary>
        /// <param name="evaluationId"></param>
        [HttpGet, Route("{evaluationId}/diagnosis")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(DiagnosisResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Diagnosis([FromRoute] int evaluationId)
        {
            var diagnosisEvaluationRegistration = new DiagnosisEvaluationRegistration(_evaluationRepository, _armPercentil);
            var diagnosis = await diagnosisEvaluationRegistration.Register(evaluationId);

            return Ok(diagnosis);
        }
    }
}
