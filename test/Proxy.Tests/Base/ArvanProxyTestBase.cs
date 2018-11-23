using Arvan.Proxy.Authorization;
using Hydrogen.General.Validation;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Arvan.Proxy.Tests.Base
{
    public class ArvanProxyTestBase
    {
        protected readonly ArvanClient Client;

        protected ArvanProxyTestBase()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("testsettings.json", false)
                .AddJsonFile("testsettings.devlocal.json", true)
                .Build();

            var apiKey = config.GetValue<string>("ApiKey");
            Client = new ArvanClient(new ApiKeyRequestAuthorization(apiKey));
        }
        
        protected T CheckSuccess<T>(ApiValidatedResult<T> result)
        {
            Assert.NotNull(result);
            Assert.True(result.Success);

            return result.Result;
        }
    }
}