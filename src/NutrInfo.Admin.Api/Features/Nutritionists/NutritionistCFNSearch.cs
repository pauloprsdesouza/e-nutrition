using System.Collections.Generic;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Nutritionists;
using NutrInfo.Admin.Api.Infrastructure.API;
using NutrInfo.Admin.Api.Infrastructure.API.Models;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;

namespace NutrInfo.Admin.Api.Features.Nutritionists
{
    public class NutritionistCFNSearch
    {
        private readonly ICFNClient _cfnClient;

        public NutritionistCFNSearch(ICFNClient cfnClient)
        {
            _cfnClient = cfnClient;
        }

        public async Task<List<Nutritionist>> Search(int region, int recordNumber)
        {
            var request = new PostCFNNutritionistRequest()
            {
                RecordNumber = recordNumber,
                Region = region
            };

            return await _cfnClient.GetNutritionist(request);
        }
    }
}
