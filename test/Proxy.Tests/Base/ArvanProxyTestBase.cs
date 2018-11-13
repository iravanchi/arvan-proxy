using Microsoft.Extensions.Configuration;

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

            Client = new ArvanClient();
            
        }
    }
}