namespace NutrInfo.Admin.Contracts.Nutritionists
{
    public class GetNutritionistsQuery
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        public int Page { get; set; }
    }
}
