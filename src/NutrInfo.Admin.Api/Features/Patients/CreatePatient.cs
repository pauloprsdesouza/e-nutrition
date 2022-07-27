using System;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Patients;
using Nutrinfo.Admin.Domain.Users;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace NutrInfo.Admin.Api.Features.Patients
{
    public class CreatePatient
    {
        private readonly ApiDbContext _dbContext;

        public CreatePatient(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Register(Patient patient)
        {
            patient.User.CreatedAt = DateTimeOffset.UtcNow;
            patient.User.Status = UserStatusEnum.Active;

            await _dbContext.Patients.AddAsync(patient);
            await _dbContext.SaveChangesAsync();
        }
    }
}
