using System;
using Microsoft.Extensions.DependencyInjection;

namespace NutrInfo.Admin.Api.Infrastructure.API
{
    public static class CFNAuthorization
    {
        public static void AddCFNAuthentication(this IServiceCollection services)
        {
            services.AddHttpClient<ICFNClient, CFNCLient>(client =>
               {
                   client.BaseAddress = new Uri("https://cnn.cfn.org.br");
               });
        }
    }
}
