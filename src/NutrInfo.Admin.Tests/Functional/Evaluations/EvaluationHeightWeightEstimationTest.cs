using System.Threading.Tasks;
using Improve.Admin.Tests.Fakes;
using NutrInfo.Admin.Api.Authorization;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Users;
using NutrInfo.Admin.Tests.Factories.Users;
using Xunit;
using NutrInfo.Admin.Tests.Factories.Patients;
using NutrInfo.Admin.Api.Models.Evaluations;
using NutrInfo.Admin.Tests.Factories.Evaluations;
using System.Net;
using NutrInfo.Admin.Tests.Factories.Nutritionists;
using System.Text.Json;
using System.Linq;
using Nutrinfo.Admin.Domain.Users;
using Nutrinfo.Admin.Domain.Patients;
using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.Nutritionists;

namespace NutrInfo.Admin.Tests.Functional.Evaluations
{
    public class EvaluationHeightWeightEstimationTest
    {
        private readonly FakeApiServer _server;
        private readonly FakeApiClient _client;

        public EvaluationHeightWeightEstimationTest()
        {
            _server = new FakeApiServer();
            _client = new FakeApiClient(_server, new ApiToken(_server.JwtOptions));
        }

        [Fact]
        public async Task ShouldCalculate()
        {
            var userNutritionist = new User().Build();
            var nutritionist = new Nutritionist().Build().WithUser(userNutritionist);

            var userPatient = new User().Build();
            var patient = new Patient().Build().WithUser(userPatient);
            var evaluation = new Evaluation().WithPatient(patient).WithNutritionist(nutritionist);

            await _server.Database.Evaluations.AddAsync(evaluation);
            await _server.Database.SaveChangesAsync();

            var getWeightHeightEstimationRequest = new GetWeightHeightEstimationRequest()
            {
                PatientId = patient.UserId,
                ArmCircumference = 32,
                KneeHeight = 55
            };

            var response = await _client.GetAsync($"api/v1/evaluations/{evaluation.Id}?patientId={patient.UserId}&armCircumference={32}&kneeHeight={55}");
            var evaluationResponse = await _client.ReadAsJsonAsync<EvaluationResponse>(response);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ShouldRespond404PatientNotFoundCalculate()
        {
            var userNutritionist = new User().Build();
            var nutritionist = new Nutritionist().Build().WithUser(userNutritionist);

            var userPatient = new User().Build();
            var patient = new Patient().Build().WithUser(userPatient);
            var evaluation = new Evaluation().WithPatient(patient).WithNutritionist(nutritionist);

            await _server.Database.Evaluations.AddAsync(evaluation);
            await _server.Database.SaveChangesAsync();

            var getWeightHeightEstimationRequest = new GetWeightHeightEstimationRequest()
            {
                PatientId = patient.UserId,
                ArmCircumference = 32,
                KneeHeight = 55
            };

            var response = await _client.GetAsync($"api/v1/evaluations/{evaluation.Id}?patientId={patient.UserId}&armCircumference={32}&kneeHeight={55}&amputatedLimbs[0]=1&amputatedLimbs[1]=2");
            var evaluationResponse = await _client.ReadAsJsonAsync<EvaluationResponse>(response);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ShouldCalculateWithAmputatedLimbs()
        {
            var userPatient = new User().Build();
            var patient = new Patient().Build().WithUser(userPatient);
            var evaluation = new Evaluation().WithPatient(patient);

            await _server.Database.Evaluations.AddAsync(evaluation);
            await _server.Database.SaveChangesAsync();

            var getWeightHeightEstimationRequest = new GetWeightHeightEstimationRequest()
            {
                PatientId = patient.UserId,
                ArmCircumference = 32,
                KneeHeight = 55
            };

            var response = await _client.GetAsync($"api/v1/evaluations/{evaluation.Id}?patientId={50}&armCircumference={32}&kneeHeight={55}");
            var responseError = await _client.ReadAsJsonAsync<JsonElement>(response);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.True(responseError.GetProperty("errors").EnumerateArray().Any(p => p.GetString() == "PATIENT_NOT_FOUND"));
        }

        [Fact]
        public async Task ShouldRespond404EvaluationNotFoundCalculate()
        {
            var userPatient = new User().Build();
            var patient = new Patient().Build().WithUser(userPatient);
            var evaluation = new Evaluation().WithPatient(patient);

            await _server.Database.Evaluations.AddAsync(evaluation);
            await _server.Database.SaveChangesAsync();

            var getWeightHeightEstimationRequest = new GetWeightHeightEstimationRequest()
            {
                PatientId = patient.UserId,
                ArmCircumference = 32,
                KneeHeight = 55
            };

            var response = await _client.GetAsync($"api/v1/evaluations/{50}?patientId={patient.UserId}&armCircumference={32}&kneeHeight={55}");
            var responseError = await _client.ReadAsJsonAsync<JsonElement>(response);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.True(responseError.GetProperty("errors").EnumerateArray().Any(p => p.GetString() == "EVALUATION_NOT_FOUND"));
        }
    }
}
