using Nutrinfo.Admin.Domain.Patients;

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

        public async Task<Patient> Update(int patientId, Patient patient)
        {
            var patientSearch = new PatientSearch(_repository);
            var patientContext = await patientSearch.Find(patientId);

            if (patientSearch.PatientNotFound)
            {
                PatientNotFound = true;
                return null;
            }

            patientContext.MapTo(patient);

            patientContext.User.UpdatedAt = DateTimeOffset.UtcNow;

            return await _repository.Update(patientContext);
        }
    }
}
