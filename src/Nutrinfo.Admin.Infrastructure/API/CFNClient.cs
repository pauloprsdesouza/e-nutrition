using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Nutrinfo.Admin.Domain.Nutritionists;
using Nutrinfo.Admin.Domain.Users;
using Nutrinfo.Admin.Infrastructure.Serialization;
using NutrInfo.Admin.Api.Infrastructure.API.Models;

namespace NutrInfo.Admin.Api.Infrastructure.API
{
    public class CFNCLient : ICFNClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public CFNCLient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions().SnakeCase();
        }

        public async Task<List<Nutritionist>> GetNutritionist(PostCFNNutritionistRequest postNutritionistRequest)
        {
            var request = new
            {
                comando = "get-nutricionista",
                options = new
                {
                    crn = postNutritionistRequest.Region,
                    geral = true,
                    registro = postNutritionistRequest.RecordNumber.ToString()
                }
            };

            var jsonContent = JsonSerializer.Serialize(request);
            var response = await _httpClient.PostAsync("/application/front-resource/get", new StringContent(jsonContent, Encoding.UTF8, "application/json"));
            var responseJson = await response.Content.ReadFromJsonAsync<JsonElement>();

            if (response.IsSuccessStatusCode)
            {
                var data = responseJson.GetProperty("data");
                var nutritionists = JsonSerializer.Deserialize<List<CFNNutritionistResponse>>(data, _jsonOptions);

                return nutritionists.Select(p => new Nutritionist() { Crn = Int32.Parse(Regex.Match(p.Registro, @"\d+").Value), User = new User() { Name = p.Nome } }).ToList();
            }

            return null;
        }
    }
}
