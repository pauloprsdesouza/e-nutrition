using Nutrinfo.Admin.Domain.Patients;
using NutrInfo.Admin.Contracts.Evaluations;

namespace NutrInfo.Admin.Contracts.Patients
{
    public static class PatientResponseMap
    {
        public static PatientResponse MapToResponse(this Patient patient)
        {
            return new PatientResponse()
            {
                Id = patient.UserId,
                Name = patient.User.Name,
                Cpf = patient.User.Cpf,
                Age = patient.User.GetAge(),
                BirthDate = patient.User.BirthDate,
                Race = patient.Race,
                Gender = patient.User.Gender,
                Email = patient.User.Email,
                Status = patient.User.Status,
                LastEvaluation = patient.Evaluations != null && patient.Evaluations.Count > 0 ? patient.Evaluations.OrderByDescending(x => x.UpdatedAt).First().MapToResponse() : null,
                CreatedAt = patient.User.CreatedAt,
                UpdatedAt = patient.User.UpdatedAt
            };
        }
    }
}
