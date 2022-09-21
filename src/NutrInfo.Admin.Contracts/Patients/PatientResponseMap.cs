using Nutrinfo.Admin.Domain.Patients;

namespace NutrInfo.Admin.Contracts.Patients
{
    public static class PatientResponseMap
    {
        public static PatientResponse MapToResponse(this Patient patient)
        {
            return new PatientResponse()
            {
                Name = patient.User.Name,
                Email = patient.User.Email,
                Status = patient.User.Status,
                CreatedAt = patient.User.CreatedAt,
                UpdatedAt = patient.User.UpdatedAt
            };
        }
    }
}
