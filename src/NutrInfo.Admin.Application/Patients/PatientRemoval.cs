using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Patients;
using Nutrinfo.Admin.Domain.Users;

namespace NutrInfo.Admin.Application.Patients
{
    public class PatientRemoval
    {
        private readonly IPatientRepository _repository;

        public PatientRemoval(IPatientRepository repository)
        {
            _repository = repository;
        }

        public bool PatientNotFound { get; private set; }

        public async Task<Patient> Delete(int patientId)
        {
            var patientSearch = new PatientSearch(_repository);
            var patient = await patientSearch.Find(patientId);

            if (patientSearch.PatientNotFound)
            {
                PatientNotFound = true;
                return null;
            }

            patient.User.Status = UserStatusEnum.Archived;

            return await _repository.Update(patient);
        }
    }
}
