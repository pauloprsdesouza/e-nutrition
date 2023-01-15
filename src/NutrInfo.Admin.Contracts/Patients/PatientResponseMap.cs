using Nutrinfo.Admin.Domain.Patients;
using NutrInfo.Admin.Contracts.Evaluations;

namespace NutrInfo.Admin.Contracts.Patients
{
    public static class PatientResponseMap
    {
        public static PatientResponse MapToResponse(this Patient patient)
        {
            var today = DateTime.Now;
            var age = today.Year - patient.User.BirthDate.Year;
            if (patient.User.BirthDate.Date > today.AddYears(-age)) age--;

            return new PatientResponse()
            {
                Id = patient.UserId,
                Name = patient.User.Name,
                Cpf = patient.User.Cpf,
                Age = age,
                Email = patient.User.Email,
                Status = patient.User.Status,
                LastEvaluation = patient.Evaluations?.OrderByDescending(x => x.UpdatedAt).First().MapToResponse(),
                CreatedAt = patient.User.CreatedAt,
                UpdatedAt = patient.User.UpdatedAt
            };
        }
    }
}
