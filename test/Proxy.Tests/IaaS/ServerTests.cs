using System.Threading.Tasks;
using Arvan.Proxy.Tests.Base;
using Xunit;

namespace Arvan.Proxy.Tests.IaaS
{
    public class ServerTests : ArvanProxyTestBase
    {
        [Fact]
        public async Task TestGetServerList()
        {
            var result = CheckSuccess(await Client.IaaS.GetServerList());
            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task TestGetDetailedServerList()
        {
            var result = CheckSuccess(await Client.IaaS.GetDetailedServerList());
            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task TestGetServerDetails()
        {
            var servers = CheckSuccess(await Client.IaaS.GetServerList());
            
            var result = CheckSuccess(await Client.IaaS.GetServerDetails(""));
            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestGetServerVncConsole()
        {
            
        }
        
        [Fact]
        public async Task TestGetServerCreationOptions()
        {
            var result = CheckSuccess(await Client.IaaS.GetServerCreationOptions());
            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task TestGetServerFlavorList()
        {
            var result = CheckSuccess(await Client.IaaS.GetServerFlavorList());
            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestGetServerActionsList()
        {
            var servers = CheckSuccess(await Client.IaaS.GetServerList());
            var result = CheckSuccess(await Client.IaaS.GetServerActionsList(""));
            Assert.NotNull(result);
        }

    }
}