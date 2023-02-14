using Nutrinfo.Admin.Domain.Users;

namespace Nutrinfo.Admin.Domain.ArmMuscleCircumferencePercentils
{
    public interface IArmMuscleCircumferencePercentilRepository
    {
        Task<ArmMuscleCircumferencePercentil> FindByGenderAndAgeAndIsAged(GenderEnum gender, int age, bool isAged);
    }
}
