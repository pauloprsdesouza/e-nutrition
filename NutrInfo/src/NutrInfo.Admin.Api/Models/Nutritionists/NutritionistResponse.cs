
using System;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;

namespace NutrInfo.Admin.Api.Models.Nutritionists
{
    public class NutritionistResponse
    {
        public int Crn { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public NutritionistStatusEnum Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
