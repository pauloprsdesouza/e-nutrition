namespace NutrInfo.Admin.Contracts.SignsAndSymptoms
{
    public class SignAndSymptomResponse
    {
        public int Id { get; set; }
        public int ClinicalChangeId { get; set; }
        public string Description { get; set; }
        public string PossibleMeanings { get; set; }
    }
}
