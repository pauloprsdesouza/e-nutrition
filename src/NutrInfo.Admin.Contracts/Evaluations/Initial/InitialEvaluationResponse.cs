namespace NutrInfo.Admin.Contracts.Evaluations.Initial
{
    public class InitialEvaluationResponse
    {
        public bool IsWalking { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double EdemaWeight { get; set; }
        public bool HasAscite { get; set; }
        public bool HasAmputatedLimb { get; set; }
    }
}
