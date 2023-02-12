using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrinfo.Admin.Domain.ClinicalChanges
{
    public interface IClinicalChangeRepository
    {
        Task<List<ClinicalChange>> FindAll();
    }
}
