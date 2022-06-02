using System;
using System.Threading.Tasks;
using NutrInfo.Admin.Api.Features.Patients;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations;
using NutrInfo.Admin.Api.Infrastructure.Formulas;
using NutrInfo.Admin.Api.Models.Evaluations;

namespace NutrInfo.Admin.Api.Features.Evaluations
{
    public class WeightHeightEstimation
    {
        private readonly ApiDbContext _dbContext;

        public WeightHeightEstimation(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool PatientNotFound { get; private set; }
        public bool EvaluationNotFound { get; private set; }

        public async Task<Evaluation> Calculate(int evaluationId, GetWeightHeightEstimationRequest request)
        {
            var patientSearch = new PatientSearch(_dbContext);
            var patient = await patientSearch.Find(request.PatientId);

            if (patientSearch.PatientNotFound)
            {
                PatientNotFound = true;
                return null;
            }

            var evaluationSearch = new EvaluationSearch(_dbContext);
            var evaluation = await evaluationSearch.Find(evaluationId);

            if (evaluationSearch.EvaluationNotFound)
            {
                EvaluationNotFound = true;
                return null;
            }

            var age = DateTime.Now.Year - patient.User.BirthDate.Year;
            var estimatedHeight = HeightEstimation.EstimateHeightByRaceAgeGender(patient.Race, age, patient.User.Gender, request.KneeHeight, request.ArmCircumference);
            var estimatedWheight = WeightEstimation.EstimateWeightByRaceAgeGender(patient.Race, age, patient.User.Gender, request.KneeHeight, request.ArmCircumference);

            evaluation.Weight = estimatedWheight;
            evaluation.Height = estimatedHeight;

            _dbContext.Evaluations.Update(evaluation);
            await _dbContext.SaveChangesAsync();

            return evaluation;
        }
    }
}
