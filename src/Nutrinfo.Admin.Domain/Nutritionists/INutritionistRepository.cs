namespace Nutrinfo.Admin.Domain.Nutritionists
{
    public interface INutritionistRepository
    {
        Task<Nutritionist> FindByName(string name);
        Task<Nutritionist> FindByCrn(int crn);
    }
}
