using Nutrinfo.Admin.Domain.Patients;

namespace NutrInfo.Admin.Application.Patients
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

        public async Task<Patient> FindByCpf(string cpf)
        {
            var patient = await _patientRepository.FindByCpf(cpf);

            PatientNotFound = patient == null;

            return patient;
        }

        public async Task<Patient> FindByEmail(string email)
        {
            var patient = await _patientRepository.FindByEmail(email);

            PatientNotFound = patient == null;

            return patient;
        }

         public async Task<Patient> FindByEvaluation(int evaluationId)
        {
            var patient = await _patientRepository.FindByEvaluation(evaluationId);

            PatientNotFound = patient == null;

            return patient;
        }
    }
}
