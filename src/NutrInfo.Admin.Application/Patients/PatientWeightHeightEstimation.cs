using Nutrinfo.Admin.Domain.Formulas;
using Nutrinfo.Admin.Domain.Patients;
using NutrInfo.Admin.Contracts.Patients.WeightHeightEstimation;

namespace NutrInfo.Admin.Application.Patients
{
    public class PatientWeightHeightEstimation
    {
        private readonly IPatientRepository _patients;
        public List<string> ValidationErrors { get; private set; }

        public PatientWeightHeightEstimation(IPatientRepository patients)
        {
            _patients = patients;
            ValidationErrors = new();
        }

        public async Task<WeightHeightEstimationResponse> Estimates(int patientId, double kneeHeight, double armCircunference)
        {
            var patient = await _patients.FindById(patientId);

            if (patient is null)
            {
                ValidationErrors.Add("PATIENT_NOT_FOUND");
                return null;
            }

            var age = patient.User.GetAge();

            var estimatedHeight = HeightEstimation.EstimateHeightByRaceAgeGender(patient.Race, age, patient.User.Gender, kneeHeight);
            var estimatedWeight = WeightEstimation.EstimateWeightByRaceAgeGender(patient.Race, age, patient.User.Gender, kneeHeight, armCircunference);

            return new WeightHeightEstimationResponse()
            {
                EstimatedWeight = estimatedWeight,
                EstimatedHeight = estimatedHeight
            };
        }
    }
}
