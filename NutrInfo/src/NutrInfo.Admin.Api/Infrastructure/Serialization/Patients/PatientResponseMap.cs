using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients;
using NutrInfo.Admin.Api.Models.Patients;

namespace NutrInfo.Admin.Api.Infrastructure.Serialization.Patients
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
