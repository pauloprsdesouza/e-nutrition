using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients
{
    public static class PatientQuery
    {
        public static IQueryable<Patient> ContainsName(this IQueryable<Patient> patients, string name)
        {
            if (string.IsNullOrEmpty(name))
                return patients;

            return patients.Where(patient => patient.User.Name.Contains(name));
        }

        public static IQueryable<Patient> WithCpf(this IQueryable<Patient> patients, string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return patients;

            return patients.Where(patient => patient.User.Cpf == cpf);
        }

        public static IQueryable<Patient> IncludeUser(this IQueryable<Patient> patients)
        {
            return patients.Include(patient => patient.User);
        }
    }
}
