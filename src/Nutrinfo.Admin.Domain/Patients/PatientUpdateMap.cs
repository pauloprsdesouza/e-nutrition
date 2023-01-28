namespace Nutrinfo.Admin.Domain.Patients
{
    public static class PatientUpdateMap
    {
        public static void MapTo(this Patient patient, Patient patientToUpdate)
        {
            patient.User.Name = patientToUpdate.User.Name;
            patient.User.Gender = patientToUpdate.User.Gender;
            patient.User.BirthDate = patientToUpdate.User.BirthDate;
            patient.User.Email = patientToUpdate.User.Email;
            patient.User.Cpf = patientToUpdate.User.Cpf;
            patient.User.Status = patientToUpdate.User.Status;
            patient.Race = patientToUpdate.Race;
        }
    }
}
