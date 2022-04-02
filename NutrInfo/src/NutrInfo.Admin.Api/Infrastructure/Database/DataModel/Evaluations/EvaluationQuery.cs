using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations
{
    public static class EvaluationQuery
    {
        public static IQueryable<Evaluation> WithPatientId(this IQueryable<Evaluation> evaluations, int patientId)
        {
            if (patientId == 0)
                return evaluations;

            return evaluations.Where(evaluation => evaluation.PatientId == patientId);
        }

        public static IQueryable<Evaluation> WithId(this IQueryable<Evaluation> evaluations, int id)
        {
            return evaluations.Where(evaluation => evaluation.Id == id);
        }

        public static IQueryable<Evaluation> SortByCreatedAt(this IQueryable<Evaluation> evaluations)
        {
            return evaluations.OrderBy(evaluation => evaluation.CreatedAt);
        }

        public static IQueryable<Evaluation> IncludePatient(this IQueryable<Evaluation> evaluations)
        {
            return evaluations.Include(evaluation => evaluation.Patient);
        }

        public static IQueryable<Evaluation> IncludeUser(this IQueryable<Evaluation> evaluations)
        {
            return evaluations.Include(evaluation => evaluation.Patient.User);
        }
    }
}
