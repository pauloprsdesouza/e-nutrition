using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.Patients;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace NutrInfo.Admin.Api.Features.Patients
{
    public class PatientSearch
    {
        private readonly IPatientRepository _patientRepository;

        public PatientSearch(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public bool PatientNotFound { get; private set; }

        public async Task<Patient> Find(int patientId)
        {
            var patient = await _patientRepository.FindById(patientId);

            PatientNotFound = patient == null;

            return patient;
        }
    }
}
