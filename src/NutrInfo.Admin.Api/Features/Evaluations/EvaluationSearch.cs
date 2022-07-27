using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.Evaluations;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace NutrInfo.Admin.Api.Features.Evaluations
{
    public class EvaluationSearch
    {
        private readonly ApiDbContext _dbContext;

        public EvaluationSearch(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool EvaluationNotFound { get; private set; }

        public async Task<Evaluation> Find(int id)
        {
            var evaluation = await _dbContext.Evaluations
                                             .Where(p => p.Id == id)
                                             .Include(p => p.Patient)
                                             .Include(p => p.Patient.User)
                                             .SingleOrDefaultAsync();

            EvaluationNotFound = evaluation == null;

            return evaluation;
        }
    }
}
