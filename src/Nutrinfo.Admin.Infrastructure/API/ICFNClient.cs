using Nutrinfo.Admin.Domain.Nutritionists;
using NutrInfo.Admin.Api.Infrastructure.API.Models;

namespace NutrInfo.Admin.Api.Infrastructure.API
{
    public interface ICFNClient
    {
        Task<List<Nutritionist>> GetNutritionist(PostCFNNutritionistRequest postNutritionistRequest);

    }
}
