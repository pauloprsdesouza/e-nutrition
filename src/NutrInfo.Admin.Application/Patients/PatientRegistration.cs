using Nutrinfo.Admin.Domain.Patients;
using Nutrinfo.Admin.Domain.Users;

namespace NutrInfo.Admin.Application.Patients
{
    public class PatientRegistration
    {
        private readonly IPatientRepository _repository;
        public List<string> ValidationErrors { get; private set; }

        public PatientRegistration(IPatientRepository repository)
        {
            _repository = repository;
            ValidationErrors = new();
        }

        public async Task<Patient> Register(Patient patient)
        {
            var patientSearch = new PatientSearch(_repository);
            var patientContext = await patientSearch.FindByCpf(patient.User.Cpf);

            if (patientContext is not null)
            {
                ValidationErrors.Add("PATIENT_ALREADY_EXISTS");
                return null;
            }

            patient.User.CreatedAt = DateTimeOffset.UtcNow;
            patient.User.Status = UserStatusEnum.ACTIVE;

            return await _repository.Create(patient);
        }
    }
}
