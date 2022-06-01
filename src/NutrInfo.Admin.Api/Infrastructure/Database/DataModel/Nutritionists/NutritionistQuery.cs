using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists
{
    public static class NutritionistQuery
    {
        public static IQueryable<Nutritionist> ContainsName(this IQueryable<Nutritionist> nutritionists, string name)
        {
            if (string.IsNullOrEmpty(name))
                return nutritionists;

            return nutritionists.Where(nutritionist => nutritionist.User.Name.Contains(name));
        }

        public static IQueryable<Nutritionist> WithCRN(this IQueryable<Nutritionist> nutritionists, int crn)
        {
            if (crn == 0)
                return nutritionists;

            return nutritionists.Where(nutritionist => nutritionist.Crn == crn);
        }

        public static IQueryable<Nutritionist> WhereCrn(this IQueryable<Nutritionist> nutritionists, int crn)
        {
            return nutritionists.Where(nutritionist => nutritionist.Crn == crn);
        }

        public static IQueryable<Nutritionist> IncludeUser(this IQueryable<Nutritionist> nutritionists)
        {
            return nutritionists.Include(nutritionist => nutritionist.User);
        }
    }
}
