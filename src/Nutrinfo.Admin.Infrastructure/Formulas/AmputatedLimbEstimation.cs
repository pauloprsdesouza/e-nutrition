using System.Collections.Generic;
using System.Linq;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.AmputatedLimbs;

namespace NutrInfo.Admin.Api.Infrastructure.Formulas
{
    public class AmputatedLimbEstimation
    {
        private List<AmputatedLimb> _amputatedLimbs;

        public AmputatedLimbEstimation()
        {
            _amputatedLimbs = new List<AmputatedLimb>();

            _amputatedLimbs.Add(new AmputatedLimb(1, "Mão", 0.7));
            _amputatedLimbs.Add(new AmputatedLimb(2, "Antebraço com mão", 2.3));
            _amputatedLimbs.Add(new AmputatedLimb(3, "Antebraço sem mão", 1.6));
            _amputatedLimbs.Add(new AmputatedLimb(4, "Parte superior do braço", 2.7));
            _amputatedLimbs.Add(new AmputatedLimb(5, "Braço inteiro", 5.0));
            _amputatedLimbs.Add(new AmputatedLimb(6, "Pé", 1.5));
            _amputatedLimbs.Add(new AmputatedLimb(7, "Perna abaixo do joelho com pé", 5.9));
            _amputatedLimbs.Add(new AmputatedLimb(8, "Coxa", 10.1));
            _amputatedLimbs.Add(new AmputatedLimb(9, "Perna inteira", 16));
            _amputatedLimbs.Add(new AmputatedLimb(10, "Ambos MMSS E MMII (tronco sem membros)", 50));
        }

        public List<AmputatedLimb> List()
        {
            return _amputatedLimbs;
        }

        public AmputatedLimb GetById(int id)
        {
            return _amputatedLimbs.Where(p => p.Id == id).SingleOrDefault();
        }

        public double Estimate(int id, double weight)
        {
            var amputatedlimb = GetById(id);
            return (weight * amputatedlimb.Percentual / 100);
        }
    }
}
