namespace NutrInfo.Admin.Contracts.BiochemistryResults
{
    public class BiochemistryResultResponse
    {
        public int BiochemistryId { get; set; }
        public int EvaluationId { get; set; }
        public double Result { get; set; }
        public string HealthExam { get; set; }
        public string Referency { get; set; }
        public double MinimumThreshold { get; set; }
        public double MaximumThreshold { get; set; }
        public string PossibleMeanings { get; set; }
    }
}
