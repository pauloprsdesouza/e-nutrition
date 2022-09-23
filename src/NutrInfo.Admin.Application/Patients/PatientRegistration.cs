using System;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Patients;
using Nutrinfo.Admin.Domain.Users;

namespace NutrInfo.Admin.Application.Patients
{
    public class PatientRegistration
    {
        private readonly IPatientRepository _repository;

        public PatientRegistration(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Patient> Register(Patient patient)
        {
            patient.User.CreatedAt = DateTimeOffset.UtcNow;
            patient.User.Status = UserStatusEnum.ACTIVE;

            return await _repository.Create(patient);
        }
    }
}
