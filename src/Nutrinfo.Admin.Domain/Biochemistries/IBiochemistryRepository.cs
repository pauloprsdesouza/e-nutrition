using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrinfo.Admin.Domain.Biochemistries
{
    public interface IBiochemistryRepository
    {
        Task<List<Biochemistry>> FindAll();
    }
}
