
using Nutrinfo.Admin.Domain.Users;

namespace NutrInfo.Admin.Contracts.Nutritionists
{
    public class NutritionistResponse
    {
        public int Id { get; set; }
        public int Crn { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
