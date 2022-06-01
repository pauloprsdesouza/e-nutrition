using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NutrInfo.Admin.Api.Configuration;
using NutrInfo.Admin.Api.Filters;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace NutrInfo.Admin.Api
{
    public class Startup
    {
        public readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApiDbContext>(options =>
           {
               options.UseNpgsql("server=localhost;Port=5440;database=postgres;user id=postgres;password=mysecretpassword", pgsql =>
               {
                   pgsql.MigrationsHistoryTable(tableName: "__migration_history", schema: ApiDbContext.Schema);
               });
           });

            services.AddControllers(options =>
           {
            //    var policy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .Build();

               //options.Filters.Add(new AuthorizeFilter(policy));
               options.Filters.Add(typeof(ExceptionFilter));
               options.Filters.Add(typeof(RequestValidationFilter));
           })
           .AddJsonOptions(options => options.JsonSerializerOptions.Default());

            services.AddSwaggerDocumentation();

            //services.AddDefaultCorsPolicy();
            //services.AddJwtAuthentication(_configuration.GetSection("JWT"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerDocumentation();

            app.UseRouting();

            //app.UseCors();
            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
