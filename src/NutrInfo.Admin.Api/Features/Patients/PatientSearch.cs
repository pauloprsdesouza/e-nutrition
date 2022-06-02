using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients;

namespace NutrInfo.Admin.Api.Features.Patients
{
    public class PatientSearch
    {
        private readonly ApiDbContext _dbContext;

        public PatientSearch(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool PatientNotFound { get; private set; }

        public async Task<Patient> Find(int patientId)
        {
            var patient = await _dbContext.Patients
                                          .WithId(patientId)
                                          .IncludeUser()
                                          .SingleOrDefaultAsync();

            PatientNotFound = patient == null;

            return patient;
        }
    }
}
