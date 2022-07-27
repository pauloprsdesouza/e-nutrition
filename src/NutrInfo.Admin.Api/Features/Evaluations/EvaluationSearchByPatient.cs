using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.Evaluations;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations;

namespace NutrInfo.Admin.Api.Features.Evaluations
{
    public class EvaluationSearchByPatient
    {
        private readonly ApiDbContext _dbContext;

        public EvaluationSearchByPatient(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool EvaluationNotFound { get; private set; }

        public async Task<Evaluation> Find(int patientId)
        {
            var evaluation = await _dbContext.Evaluations
                                             .WithPatientId(patientId)
                                             .IncludePatient()
                                             .IncludeUser()
                                             .SortByCreatedAt()
                                             .LastOrDefaultAsync();

            EvaluationNotFound = evaluation == null;

            return evaluation;
        }
    }
}
