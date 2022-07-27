using System;
using Nutrinfo.Admin.Domain.Users;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Users;

namespace NutrInfo.Admin.Api.Models.Patients
{
    public class PatientResponse
    {
        public int Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserStatusEnum Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
