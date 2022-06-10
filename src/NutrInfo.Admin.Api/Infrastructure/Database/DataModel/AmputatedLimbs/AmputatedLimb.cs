namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.AmputatedLimbs
{
    public class AmputatedLimb
    {
        public int Id { get; set; }
        public string LimbName { get; set; }
        public double Percentual { get; set; }

        public AmputatedLimb(int id, string limbName, double percentual)
        {
            this.Id = id;
            this.LimbName = limbName;
            this.Percentual = percentual;
        }
    }
}
