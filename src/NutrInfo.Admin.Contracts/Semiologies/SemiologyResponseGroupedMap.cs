using Nutrinfo.Admin.Domain.Semiologies;

namespace NutrInfo.Admin.Contracts.Semiologies
{
    public static class SemiologyResponseGroupedMap
    {
        public static KeyValuePair<string, List<SemiologyResponse>> MapToResponse(this KeyValuePair<string, List<Semiology>> semiology)
        {
            return new KeyValuePair<string, List<SemiologyResponse>>(semiology.Key, semiology.Value.Select(x => x.MapToResponse()).ToList());
        }
    }
}
