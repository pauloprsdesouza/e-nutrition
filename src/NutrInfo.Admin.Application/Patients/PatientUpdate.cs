using Nutrinfo.Admin.Domain.Patients;
using NutrInfo.Admin.Contracts.Patients;

namespace NutrInfo.Admin.Application.Patients
{
    public class PatientUpdate
    {
        private readonly IPatientRepository _repository;

        public PatientUpdate(IPatientRepository repository)
        {
            _repository = repository;
        }

        public bool PatientNotFound { get; private set; }

        public async Task<Patient> Update(int patientId, PutPatientRequest patientRequest)
        {
            var patientSearch = new PatientSearch(_repository);
            var patient = await patientSearch.Find(patientId);

            if (patientSearch.PatientNotFound)
            {
                PatientNotFound = true;
                return null;
            }

            patientRequest.MapTo(patient);

            patient.User.UpdatedAt = DateTimeOffset.UtcNow;

            return await _repository.Update(patient);
        }
    }
}
