
using Nutrinfo.Admin.Domain.Users;

namespace NutrInfo.Admin.Contracts.Nutritionists
{
    public class NutritionistResponse
    {
        public int Crn { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserStatusEnum Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
