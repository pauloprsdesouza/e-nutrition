namespace Nutrinfo.Admin.Domain.Evaluations
{
    public interface IEvaluationRepository
    {
        Task<Evaluation> Create(Evaluation evaluation);
    }
}
