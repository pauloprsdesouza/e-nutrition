using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.Patients;
using NutrInfo.Admin.Contracts.Evaluations;

namespace NutrInfo.Admin.Contracts.Patients
{
    public static class PatientResponseMap
    {
        public static PatientResponse MapToResponse(this Patient patient)
        {
            var lastCompletedEvaluation = patient.Evaluations.Where(x => x.Status == EvaluationStatusEnum.COMPLETED).Any() ? patient.Evaluations.Where(x => x.Status == EvaluationStatusEnum.COMPLETED).OrderBy(x => x.CreatedAt).First() : null;
            var processingEvaluation = patient.Evaluations.Where(x => x.Status == EvaluationStatusEnum.PROCESSING).Any() ? patient.Evaluations.Where(x => x.Status == EvaluationStatusEnum.PROCESSING).OrderBy(x => x.CreatedAt).First() : null;

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
                LastEvaluation = lastCompletedEvaluation?.MapToResponse(),
                ProcessingEvaluation = processingEvaluation?.MapToResponse(),
                CreatedAt = patient.User.CreatedAt,
                UpdatedAt = patient.User.UpdatedAt
            };
        }
    }
}
