using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
