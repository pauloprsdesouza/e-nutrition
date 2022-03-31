using System;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists
{
    public class Nutritionist
    {
        public int Crn { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public NutritionistStatusEnum Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
