using Nutrinfo.Admin.Domain.Users;

namespace Nutrinfo.Admin.Domain.CircumferencePercentils
{
    public interface IArmCircumferencePercentilRepository
    {
        Task<ArmCircumferencePercentil> FindByGenderAndAge(GenderEnum gender, int age);
    }
}
