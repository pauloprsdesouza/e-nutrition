namespace NutrInfo.Admin.Contracts.Semiologies
{
    public class GetSemiologyResponse
    {
        public List<KeyValuePair<string, List<SemiologyResponse>>> Semiologies { get; set; }
    }
}
