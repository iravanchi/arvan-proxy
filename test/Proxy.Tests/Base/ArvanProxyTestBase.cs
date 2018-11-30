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

            Client = BuildClient(config);
        }

        private static ArvanClient BuildClient(IConfigurationRoot config)
        {
            var apiKey = config.GetValue<string>("ApiKey");
            var bearerToken = config.GetValue<string>("BearerToken");

            RequestAuthorizationBase authorization = null;
            if (!string.IsNullOrWhiteSpace(apiKey))
                authorization = new ApiKeyRequestAuthorization(apiKey);
            else if (!string.IsNullOrWhiteSpace(bearerToken))
                authorization = new BearerRequestAuthorization(bearerToken);
            
            return new ArvanClient(authorization);
        }

        protected T CheckSuccess<T>(ApiValidatedResult<T> result)
        {
            Assert.NotNull(result);
            Assert.True(result.Success);

            return result.Result;
        }
    }
}