namespace Nutrinfo.Admin.Domain.Nutritionists
{
    public interface INutritionistRepository
    {
        Task<Nutritionist> FindByName(string name);
        Task<Nutritionist> FindByCrn(int crn);
        Task<Nutritionist> Update(Nutritionist nutritionist);
        Task<Nutritionist> Create(Nutritionist nutritionist);
        Task<List<Nutritionist>> FindAll();
    }
}
