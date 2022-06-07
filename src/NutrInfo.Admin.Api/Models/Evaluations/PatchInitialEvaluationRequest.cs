using System.Collections.Generic;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.AmputatedLimbs;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations;
using NutrInfo.Admin.Api.Infrastructure.Formulas;

namespace NutrInfo.Admin.Api.Models.Evaluations
{
    public class PatchInitialEvaluationRequest
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public bool IsWalking { get; set; }
        public bool HasEdema { get; set; }
        public bool HasAscite { get; set; }
        public bool HasAmputatedLimb { get; set; }
        public double KneeHeight { get; set; }
        public double ArmCircumference { get; set; }
        public EdemaEnum Edema { get; set; }
        public double WeightEdema { get; set; }
        public DiseaseSeverityEnum AsciticAscite { get; set; }
        public DiseaseSeverityEnum PeripheralAscite { get; set; }
       public List<AmputatedLimb> AmputatedLimbs { get; set; }

        public void MapTo(Evaluation evaluation)
        {
            evaluation.Height = Height;
            evaluation.Weight = Weight;
            evaluation.IsWalking = IsWalking;
            evaluation.HasEdema = HasEdema;
            evaluation.HasAscite = HasAscite;
            evaluation.HasAmputatedLimb = HasAmputatedLimb;
            evaluation.AmputatedLimbs = AmputatedLimbs;
        }
    }
}
