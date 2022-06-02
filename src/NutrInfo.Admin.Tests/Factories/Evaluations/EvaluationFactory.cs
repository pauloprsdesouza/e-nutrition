using System;
using Bogus;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients;

namespace NutrInfo.Admin.Tests.Factories.Evaluations
{
    public static class EvaluationFactory
    {
        public static Evaluation Build(this Evaluation evaluation)
        {
            var evaluationFaker = new Faker<Evaluation>()
            .RuleFor(p => p.BedNumber, f => f.Random.Int(1, 50))
            .RuleFor(p => p.Energy, f => f.Random.Double(1, 500))
            .RuleFor(p => p.HasAmputatedLimb, f => f.Random.Bool())
            .RuleFor(p => p.HasAscite, f => f.Random.Bool())
            .RuleFor(p => p.HasEdema, f => f.Random.Bool())
            .RuleFor(p => p.DiseaseSeverity, f => f.PickRandom<DiseaseSeverityEnum>())
            .RuleFor(p => p.Height, f => f.Random.Double(150, 220))
            .RuleFor(p => p.Weight, f => f.Random.Double(20, 200))
            .RuleFor(p => p.IsWalking, f => f.Random.Bool())
            .RuleFor(p => p.Protein, f => f.Random.Double(200, 5000))
            .RuleFor(p => p.CreatedAt, f => DateTimeOffset.UtcNow);

            return evaluationFaker.Generate();
        }

        public static Evaluation WithPatient(this Evaluation evaluation, Patient patient)
        {
            evaluation.Patient = patient;
            evaluation.PatientId = patient.UserId;

            return evaluation;
        }

        public static Evaluation WithNutritionist(this Evaluation evaluation, Nutritionist nutritionist)
        {
            evaluation.Nutritionist = nutritionist;
            evaluation.NutritionistId = nutritionist.UserId;

            return evaluation;
        }
    }
}
