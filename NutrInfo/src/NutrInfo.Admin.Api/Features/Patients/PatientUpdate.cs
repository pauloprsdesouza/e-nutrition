using System;
using System.Threading.Tasks;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients;

namespace NutrInfo.Admin.Api.Features.Patients
{
    public class PatientUpdate
    {
        private readonly ApiDbContext _dbContext;

        public PatientUpdate(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Update(Patient patient)
        {
            patient.User.UpdatedAt = DateTimeOffset.UtcNow;

            _dbContext.Patients.Update(patient);
            await _dbContext.SaveChangesAsync();
        }
    }
}
