namespace Nutrinfo.Admin.Domain.Evaluations
{
    public interface IEvaluationRepository
    {
        Task<Evaluation> Create(Evaluation evaluation);
        Task<Evaluation> Update(Evaluation evaluation);
        Task<Evaluation> FindById(int evaluationId);
        Task<List<Evaluation>> FindLastTwoEvaluationsFromPatient(int patientId);
    }
}
