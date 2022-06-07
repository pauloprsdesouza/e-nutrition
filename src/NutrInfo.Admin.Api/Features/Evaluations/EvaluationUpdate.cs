using System;
using System.Threading.Tasks;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations;
using NutrInfo.Admin.Api.Infrastructure.Formulas;
using NutrInfo.Admin.Api.Models.Evaluations;

namespace NutrInfo.Admin.Api.Features.Evaluations
{
    public class EvaluationUpdate
    {
        private readonly ApiDbContext _dbContext;

        public EvaluationUpdate(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool PatientNotFound { get; private set; }
        public bool EvaluationNotFound { get; private set; }
        public bool WeightEdemaInvalid { get; private set; }

        public async Task<Evaluation> Register(int evaluationId, PatchInitialEvaluationRequest request)
        {
            var evaluationSearch = new EvaluationSearch(_dbContext);
            var evaluation = await evaluationSearch.Find(evaluationId);

            if (evaluationSearch.EvaluationNotFound)
            {
                EvaluationNotFound = true;
                return null;
            }

            if (request.HasEdema)
            {
                switch (request.Edema)
                {
                    case EdemaEnum.ANKLE_ONLY:
                        request.Weight -= 1;
                        break;
                    case EdemaEnum.UP_KNEE:
                        if (request.WeightEdema >= 3 && request.WeightEdema <= 4)
                            request.Weight -= request.WeightEdema;
                        else
                        {
                            WeightEdemaInvalid = true;
                            return null;
                        }
                        break;
                    case EdemaEnum.UP_THIGH:
                        if (request.WeightEdema >= 5 && request.WeightEdema <= 6)
                            request.Weight -= request.WeightEdema;
                        else
                        {
                            WeightEdemaInvalid = true;
                            return null;
                        }
                        break;
                    case EdemaEnum.ANASARCA:
                        if (request.WeightEdema >= 10 && request.WeightEdema <= 12)
                            request.Weight -= request.WeightEdema;
                        else
                        {
                            WeightEdemaInvalid = true;
                            return null;
                        }
                        break;
                }
            }

            if (request.HasAscite)
            {
                switch (request.AsciticAscite)
                {
                    case DiseaseSeverityEnum.Light:
                        request.Weight -= AsciteRate.ASCITIC_WEIGHT_LIGHT;
                        break;
                    case DiseaseSeverityEnum.Moderate:
                        request.Weight -= AsciteRate.ASCITIC_WEIGHT_MODERATE;
                        break;
                    case DiseaseSeverityEnum.Severe:
                        request.Weight -= AsciteRate.ASCITIC_WEIGHT_SEVERE;
                        break;
                }

                switch (request.PeripheralAscite)
                {
                    case DiseaseSeverityEnum.Light:
                        request.Weight -= AsciteRate.PERIPHERAL_WEIGHT_LIGHT;
                        break;
                    case DiseaseSeverityEnum.Moderate:
                        request.Weight -= AsciteRate.PERIPHERAL_WEIGHT_MODERATE;
                        break;
                    case DiseaseSeverityEnum.Severe:
                        request.Weight -= AsciteRate.PERIPHERAL_WEIGHT_SEVERE;
                        break;
                }
            }

            request.MapTo(evaluation);

            evaluation.CreatedAt = DateTimeOffset.UtcNow;

            _dbContext.Evaluations.Update(evaluation);
            await _dbContext.SaveChangesAsync();

            return evaluation;
        }
    }
}
