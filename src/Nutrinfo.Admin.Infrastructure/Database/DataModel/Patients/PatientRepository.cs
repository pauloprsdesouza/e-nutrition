using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.Patients;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.Patients
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly DbSet<Patient> _patients;

        public PatientRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _patients = dbContext.Set<Patient>();
        }

        public async Task<Patient> Create(Patient patient)
        {
            await _patients.AddAsync(patient);
            await _dbContext.SaveChangesAsync();

            return patient;
        }

        public async Task<Patient> FindById(int id)
        {
            return await _patients.Where(x => x.UserId == id).SingleOrDefaultAsync();
        }

        public async Task<Patient> Update(Patient patient)
        {
            _patients.Update(patient);
            await _dbContext.SaveChangesAsync();

            return patient;
        }
    }
}
