
namespace  NutrInfo.Admin.Api.Authorization
{
    public class JwtOptions
    {
        public const string Issuer = "https://api.improvecursos.com.br";

        public const string Audience = "https://client.improvecursos.com.br";

        public string Secret { get; set; }
    }
}
