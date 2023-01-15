using System;
using Nutrinfo.Admin.Domain.Users;
using NutrInfo.Admin.Contracts.Evaluations;

namespace NutrInfo.Admin.Contracts.Patients
{
    public class PatientResponse
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public EvaluationResponse LastEvaluation { get; set; }
        public UserStatusEnum Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
