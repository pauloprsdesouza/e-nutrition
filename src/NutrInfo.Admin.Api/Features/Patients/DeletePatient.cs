using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Patients;
using Nutrinfo.Admin.Domain.Users;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace NutrInfo.Admin.Api.Features.Patients
{
    public class DeletePatient
    {
        private readonly ApiDbContext _dbContext;

        public DeletePatient(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Delete(Patient patient)
        {
            patient.User.Status = UserStatusEnum.Archived;

            _dbContext.Patients.Update(patient);
            await _dbContext.SaveChangesAsync();
        }
    }
}
