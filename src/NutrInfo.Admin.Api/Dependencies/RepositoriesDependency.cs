using Microsoft.Extensions.DependencyInjection;
using Nutrinfo.Admin.Api.Infrastructure.Database.DataModel.Ascites;
using Nutrinfo.Admin.Domain.AmputatedLimbs;
using Nutrinfo.Admin.Domain.AmputatedLimbsPercentage;
using Nutrinfo.Admin.Domain.AsciteDegrees;
using Nutrinfo.Admin.Domain.Ascites;
using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.Nutritionists;
using Nutrinfo.Admin.Domain.Patients;
using Nutrinfo.Admin.Infrastructure.Database.DataModel.AmputatedLimbs;
using Nutrinfo.Admin.Infrastructure.Database.DataModel.AmputatedLimbsPercentage;
using Nutrinfo.Admin.Infrastructure.Database.DataModel.AsciteDegrees;
using Nutrinfo.Admin.Infrastructure.Database.DataModel.Evaluations;
using Nutrinfo.Admin.Infrastructure.Database.DataModel.Nutritionists;
using Nutrinfo.Admin.Infrastructure.Database.DataModel.Patients;

namespace NutrInfo.Admin.Api.Dependencies
{
    public static class RepositoriesDependency
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<INutritionistRepository, NutritionistRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IEvaluationRepository, EvaluationRepository>();
            services.AddScoped<IAmputatedLimbRepository, AmputatedLimbRepository>();
            services.AddScoped<IAmputatedLimbPercentageRepository, AmputatedLimbPercentageRepository>();
            services.AddScoped<IAsciteRepository, AsciteRepository>();
            services.AddScoped<IAsciteDegreeRepository, AsciteDegreeRepository>();
        }
    }
}
