using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrinfo.Admin.Domain.NutritionalStatesSemiology
{
    public interface INutritionalStateSemiologyRepository
    {
        Task<NutritionalStateSemiology> FindById(int id);
        Task<List<NutritionalStateSemiology>> FindAll();
    }
}
