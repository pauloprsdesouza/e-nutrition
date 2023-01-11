using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.Pagination;
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

        public async Task<PagedList<Patient>> FindPaged(string name, int page)
        {
             IQueryable<Patient> query = _patients.Include(x => x.User);

            if(name is not null) {
                query = query.Where(x => x.User.Name.ToLower().Contains(name.ToLower())).AsQueryable();
            }

            return await PagedList<Patient>.CreateAsync(query, page);
        }

        public async Task<Patient> Update(Patient patient)
        {
            _patients.Update(patient);
            await _dbContext.SaveChangesAsync();

            return patient;
        }
    }
}
