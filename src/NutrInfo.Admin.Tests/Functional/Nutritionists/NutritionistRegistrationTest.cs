using System.Linq;
using System.Threading.Tasks;
using Improve.Admin.Tests.Fakes;
using NutrInfo.Admin.Api.Authorization;
using NutrInfo.Admin.Tests.Factories.Users;
using Xunit;
using NutrInfo.Admin.Tests.Factories.Nutritionists;
using NutrInfo.Admin.Tests.Factories.Addresses;
using System.Net;
using Nutrinfo.Admin.Domain.Nutritionists;
using Nutrinfo.Admin.Domain.Users;
using Nutrinfo.Admin.Domain.Addresses;
using NutrInfo.Admin.Contracts.Nutritionists;

namespace NutrInfo.Admin.Tests.Functional.Nutritionists
{
    public class NutritionistRegistrationTest
    {
        private readonly FakeApiServer _server;
        private readonly FakeApiClient _client;

        public NutritionistRegistrationTest()
        {
            _server = new FakeApiServer();
            _client = new FakeApiClient(_server, new ApiToken(_server.JwtOptions));
        }

        [Fact]
        public async Task ShouldCreate()
        {
            var user = new User().Build();
            var address = new Address().Build().WithUser(user);

            await _server.Database.Addresses.AddAsync(address);
            await _server.Database.SaveChangesAsync();

            var nutritionist = new Nutritionist().Build().WithUser(user);

            var postNutritionistRequest = new PostNutritionistRequest().To(nutritionist);

            var response = await _client.PostJsonAsync("api/v1/nutritionists", postNutritionistRequest);
            var nutritionistResponse = await _client.ReadAsJsonAsync<NutritionistResponse>(response);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(nutritionist.Crn, nutritionistResponse.Crn);
        }
    }
}
