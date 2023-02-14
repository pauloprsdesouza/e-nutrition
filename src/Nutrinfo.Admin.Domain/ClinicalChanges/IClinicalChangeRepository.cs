namespace Nutrinfo.Admin.Domain.ClinicalChanges
{
    public interface IClinicalChangeRepository
    {
        Task<List<ClinicalChange>> FindAll();
        Task<ClinicalChange> FindById(int clinicalChangeId);
    }
}
