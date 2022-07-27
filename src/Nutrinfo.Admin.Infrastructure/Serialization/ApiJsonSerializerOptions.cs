using System.Text.Json;
using System.Text.Json.Serialization;
using Nutrinfo.Admin.Infrastructure.Serialization;

namespace Nutrinfo.Admin.Infrastructure.Serialization
{
    public static class ApiJsonSerializerOptions
    {
        public static JsonSerializerOptions Default(this JsonSerializerOptions options)
        {
            options.PropertyNameCaseInsensitive = true;
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.Converters.Add(new JsonStringEnumConverter());

            return options;
        }


        public static JsonSerializerOptions SnakeCase(this JsonSerializerOptions options)
        {
            options.PropertyNameCaseInsensitive = false;
            options.PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance;

            return options;
        }
    }
}
