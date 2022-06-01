using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using NutrInfo.Admin.Api.Authorization;
using NutrInfo.Admin.Api.Configuration;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Users;

namespace Improve.Admin.Tests.Fakes
{
    public class FakeApiClient
    {
        private readonly HttpClient _client;

        public FakeApiClient(TestServer server)
        {
            _client = server.CreateClient();
        }

        public FakeApiClient(TestServer server, ApiToken token = null)
        {
            _client = server.CreateClient();

            if (token != null)
            {
                token.User = new User()
                {
                    Id = 1,
                    Email = "paulo.prsdesouza@gmail.com",
                    Nutritionist = new Nutritionist()
                    {
                        Password = "$2a$11$Rxl.pam5ZYmhQhjeyn18RuijF/GueCoJGl.8QdW3En.jGNZmK518m"
                    }
                    //Roles = new List<string>() { "Administrator" }
                };

                _client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.ToString());
            }
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return await _client.GetAsync(requestUri);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            return await _client.DeleteAsync(requestUri);
        }

        public async Task<HttpResponseMessage> PostJsonAsync(string requestUri, object content)
        {
            var jsonContent = JsonSerializer.Serialize(content);
            return await PostJsonAsync(requestUri, jsonContent);
        }

        public async Task<HttpResponseMessage> PostJsonAsync(string requestUri, string content)
        {
            var jsonContent = new StringContent(content, Encoding.UTF8, "application/json");
            return await _client.PostAsync(requestUri, jsonContent);
        }

        public async Task<HttpResponseMessage> PostJsonAsync(string requestUri)
        {
            var jsonContent = new StringContent("{}", Encoding.UTF8, "application/json");
            return await _client.PostAsync(requestUri, jsonContent);
        }

        public async Task<HttpResponseMessage> PutJsonAsync(string requestUri, object content)
        {
            var jsonContent = JsonSerializer.Serialize(content);
            return await PutJsonAsync(requestUri, jsonContent);
        }

        public async Task<HttpResponseMessage> PutJsonAsync(string requestUri, string content)
        {
            var jsonContent = new StringContent(content, Encoding.UTF8, "application/json");
            return await _client.PutAsync(requestUri, jsonContent);
        }

        public async Task<HttpResponseMessage> PutJsonAsync(string requestUri)
        {
            var jsonContent = new StringContent("{}", Encoding.UTF8, "application/json");
            return await _client.PutAsync(requestUri, jsonContent);
        }

        public async Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
        {
            return await _client.PutAsync(requestUri, content);
        }

        public async Task<JsonElement> ReadJsonAsync(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<JsonElement>(json);
        }

        public async Task<TResult> ReadAsJsonAsync<TResult>(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResult>(json, new JsonOptions().JsonSerializerOptions.Default());
        }
    }
}
