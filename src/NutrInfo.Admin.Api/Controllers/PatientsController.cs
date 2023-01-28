using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrinfo.Admin.Domain.Patients;
using NutrInfo.Admin.Application.Patients;
using NutrInfo.Admin.Contracts;
using NutrInfo.Admin.Contracts.Paginations;
using NutrInfo.Admin.Contracts.Patients;
using NutrInfo.Admin.Contracts.Patients.WeightHeightEstimation;

namespace NutrInfo.Admin.Api.Controllers
{
    [Route("api/v1/patients")]
    public class PatientsController : Controller
    {
        private readonly IPatientRepository _patientRepository;

        public PatientsController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        /// <summary>
        /// Estimates a Weight and Height from a patient
        /// </summary>
        [HttpGet, Route("{patientId}/estimates-weight-height")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(WeightHeightEstimationResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> EstimatesWeightAndHeight([FromRoute] int patientId, [FromQuery] GetWeightHeightEstimationQuery queryString)
        {
            var weightHeightEstimation = new PatientWeightHeightEstimation(_patientRepository);
            var estimation = await weightHeightEstimation.Estimates(patientId, queryString.KneeHeight, queryString.ArmCircunference);

            if (weightHeightEstimation.ValidationErrors.Any())
            {
                return UnprocessableEntity(new ResponseError(weightHeightEstimation.ValidationErrors));
            }

            return Ok(estimation);
        }

        /// <summary>
        /// List all registered patients
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(GetPatientResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> List([FromQuery] GetPatientsQuery queryString)
        {
            var patients = await _patientRepository.FindPaged(queryString.Name, queryString.Page);

            return Ok(new GetPatientResponse()
            {
                Patients = patients.Select(x => x.MapToResponse()),
                Pagination = new PaginationResponseMap<Patient>().MapToResponse(patients)
            });
        }

        /// <summary>
        /// Find a registered patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [HttpGet, Route("{patientId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(PatientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Find([FromRoute] int patientId)
        {
            var patientSearch = new PatientSearch(_patientRepository);
            var patient = await patientSearch.Find(patientId);

            if (patientSearch.PatientNotFound)
            {
                return NotFound(new ResponseError("PATIENT_NOT_FOUND"));
            }

            return Ok(patient.MapToResponse());
        }

        /// <summary>
        /// Create a new patient
        /// </summary>
        /// <param name="patientRequest"></param>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(PatientResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] PostPatientRequest patientRequest)
        {
            var createPatient = new PatientRegistration(_patientRepository);
            var patient = await createPatient.Register(patientRequest.ToPatient());

            return Created($"api/v1/patients/{patient}", patient.MapToResponse());
        }

        /// <summary>
        /// Update a registered patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="patientRequest"></param>
        /// <returns></returns>
        [HttpPut, Route("{patientId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(PatientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] int patientId, [FromBody] PutPatientRequest patientRequest)
        {
            var patientUpdate = new PatientUpdate(_patientRepository);
            var patient = await patientUpdate.Update(patientId, patientRequest.ToPatient());

            if (patientUpdate.PatientNotFound)
            {
                return NotFound(new ResponseError("PATIENT_NOT_FOUND"));
            }

            return Ok(patient.MapToResponse());
        }

        /// <summary>
        /// Delete a registered patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [HttpDelete, Route("{patientId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(PatientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int patientId)
        {
            var patientRemoval = new PatientRemoval(_patientRepository);
            var patient = await patientRemoval.Delete(patientId);

            if (patientRemoval.PatientNotFound)
            {
                return NotFound(new ResponseError("PATIENT_NOT_FOUND"));
            }

            return Ok(patient.MapToResponse());
        }

        /// <summary>
        /// Delete a registered patient
        /// </summary>
        /// <param name="evaluationId"></param>
        /// <returns></returns>
        [HttpGet, Route("{evaluationId}/lastevaluation")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(PatientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindByEvaluationId([FromRoute] int evaluationId)
        {
            var patientSearch = new PatientSearch(_patientRepository);
            var patient = await patientSearch.FindByEvaluation(evaluationId);

            if (patientSearch.PatientNotFound)
            {
                return NotFound(new ResponseError("PATIENT_NOT_FOUND"));
            }

            return Ok(patient.MapToResponse());
        }
    }
}
