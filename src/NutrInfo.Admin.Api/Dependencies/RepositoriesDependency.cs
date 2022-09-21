using Microsoft.Extensions.DependencyInjection;
using Nutrinfo.Admin.Domain.Nutritionists;
using Nutrinfo.Admin.Domain.Patients;
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
        }
    }
}
