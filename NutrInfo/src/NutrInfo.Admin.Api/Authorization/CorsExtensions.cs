using Microsoft.Extensions.DependencyInjection;

namespace  NutrInfo.Admin.Api.Authorization
{
    public static class CorsExtensions
    {
        public static void AddDefaultCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy => policy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
    }
}
