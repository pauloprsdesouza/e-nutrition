using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NutrInfo.Admin.Api.Authorization;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace Improve.Admin.Tests.Fakes
{
    public sealed class FakeApiServer : TestServer
    {
        public FakeApiServer() : base(new Program().CreateWebHostBuilder()) { }

        public IWebHostEnvironment Environment => Host.Services.GetService<IWebHostEnvironment>();
        public ApiDbContext Database => Host.Services.GetService<ApiDbContext>();
        public IOptions<JwtOptions> JwtOptions => Host.Services.GetService<IOptions<JwtOptions>>();
    }
}
