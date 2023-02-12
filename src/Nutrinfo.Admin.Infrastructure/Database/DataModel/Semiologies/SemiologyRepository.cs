using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.Semiologies;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.Semiologies
{
    public class SemiologyRepository : ISemiologyRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly DbSet<Semiology> _semiologies;

        public SemiologyRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _semiologies = dbContext.Set<Semiology>();
        }

        public async Task<List<Semiology>> FindAll()
        {
            return await _semiologies.ToListAsync();
        }
    }
}
