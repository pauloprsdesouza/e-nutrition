using Nutrinfo.Admin.Domain.Biochemistries;

namespace NutrInfo.Admin.Contracts.Biochemistries
{
    public static class BiochemistryResponseMap
    {
        public static BiochemistryResponse MapToResponse(this Biochemistry biochemistry)
        {
            return new BiochemistryResponse()
            {
                Id = biochemistry.Id,
                HealthExam = biochemistry.HealthExam,
                MinimumThreshold = biochemistry.MinimumThreshold,
                MaximumThreshold = biochemistry.MaximumThreshold,
                PossibleMeanings = biochemistry.PossibleMeanings
            };
        }
    }
}
