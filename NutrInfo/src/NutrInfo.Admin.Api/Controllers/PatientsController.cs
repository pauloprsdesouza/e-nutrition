using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutrInfo.Admin.Api.Features.Patients;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients;
using NutrInfo.Admin.Api.Infrastructure.Serialization.Patients;
using NutrInfo.Admin.Api.Models.Patients;

namespace NutrInfo.Admin.Api.Controllers
{
    [Route("Patients")]
    public class PatientsController : Controller
    {
        private readonly ApiDbContext _dbContext;

        public PatientsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
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
            var patients = await _dbContext.Patients
                                           .WithCpf(queryString.Cpf)
                                           .IncludeUser()
                                           .ToListAsync();

            return Ok(new GetPatientResponse()
            {
                Patients = patients.Select(patient => patient.MapToResponse())
            });
        }

        /// <summary>
        /// Find a registered patient
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [HttpGet, Route("{cpf}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(PatientResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Find([FromRoute] string cpf)
        {
            var patientSearch = new PatientSearch(_dbContext);
            var patient = await patientSearch.Find(cpf);

            if (patientSearch.PatientNotFound)
            {
                return NotFound();
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
            var patientSearch = new PatientSearch(_dbContext);
            var patient = await patientSearch.Find(patientRequest.Cpf);

            if (patient == null)
            {
                var createPatient = new CreatePatient(_dbContext);
                patient = patientRequest.ToPatient();
                await createPatient.Register(patient);
            }

            return Created("", patient.MapToResponse());
        }

        /// <summary>
        /// Update a registered patient
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="patientRequest"></param>
        /// <returns></returns>
        [HttpPut, Route("{cpf}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(PatientResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute] string cpf, [FromBody] PutPatientRequest patientRequest)
        {
            var patientSearch = new PatientSearch(_dbContext);
            var patient = await patientSearch.Find(cpf);

            if (patientSearch.PatientNotFound)
            {
                return NotFound();
            }

            var updatePatient = new PatientUpdate(_dbContext);
            patientRequest.MapTo(patient);

            await updatePatient.Update(patient);

            return Ok(patient.MapToResponse());
        }

        /// <summary>
        /// Delete a registered patient
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [HttpDelete, Route("{cpf}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(PatientResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] string cpf)
        {
            var patientSearch = new PatientSearch(_dbContext);
            var patient = await patientSearch.Find(cpf);

            if (patientSearch.PatientNotFound)
            {
                return NotFound();
            }

            var deletePatient = new DeletePatient(_dbContext);
            await deletePatient.Delete(patient);

            return Ok(patient.MapToResponse());
        }
    }
}
