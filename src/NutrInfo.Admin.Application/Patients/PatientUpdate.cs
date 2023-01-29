using Nutrinfo.Admin.Domain.Patients;

namespace NutrInfo.Admin.Application.Patients
{
    public class PatientUpdate
    {
        private readonly IPatientRepository _repository;
        public List<string> ValidationErrors { get; private set; }

        public PatientUpdate(IPatientRepository repository)
        {
            _repository = repository;
            ValidationErrors = new();
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

            if (patientContext is not null)
            {
                ValidationErrors.Add("PATIENT_ALREADY_EXISTS");
                return null;
            }

            if (patient.User.Email is not null)
            {
                patientContext = await patientSearch.FindByEmail(patient.User.Email);

                if (patientContext is not null)
                {
                    ValidationErrors.Add("PATIENT_ALREADY_EXISTS");
                    return null;
                }
            }

            patientContext.MapTo(patient);

            patientContext.User.UpdatedAt = DateTimeOffset.UtcNow;

            return await _repository.Update(patientContext);
        }
    }
}
