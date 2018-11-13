using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Arvan.Proxy.Tests.IaaS
{
    public class GetFloatingIpListTests
    {
        private  readonly string _settingsField;
        
        public GetFloatingIpListTests()
        {
            _settingsField = GetApplicationConfiguration();
        }

        [Fact]
        public async Task CheckInvocationWithoutErrors()
        {
            var arvan = new ArvanClient();
            var result = await arvan.IaaS.GetFloatIpList();
            
            Assert.NotNull(result);
        }
        
        public static IConfigurationRoot GetIConfigurationRoot()
        {            
            return new ConfigurationBuilder()
                .AddJsonFile("testsettings.json", false)
                .AddJsonFile("testsettings.devlocal.json", false)
                .AddUserSecrets("883cd70e-d90b-41fc-a7dd-47695db0d616")
                .AddEnvironmentVariables()
                .Build();
        }
        
        public static string GetApplicationConfiguration()
        {
            var iConfig = GetIConfigurationRoot();
            return iConfig.GetSection("SomeField").GetValue<string>("AnotherField");
        }
    }
}