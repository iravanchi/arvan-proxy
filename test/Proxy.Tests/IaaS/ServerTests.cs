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
            // Assuming there is at least one server present and returned
            Assert.NotNull(servers);
            Assert.NotNull(servers.Data);
            Assert.NotEmpty(servers.Data);
            
            var result = CheckSuccess(await Client.IaaS.GetServerDetails(servers.Data[0].Id));
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task TestGetServerVncConsole()
        {
            var servers = CheckSuccess(await Client.IaaS.GetServerList());
            // Assuming there is at least one server present and returned
            Assert.NotNull(servers);
            Assert.NotNull(servers.Data);
            Assert.NotEmpty(servers.Data);
            
            var result = CheckSuccess(await Client.IaaS.GetServerVncConsole(servers.Data[0].Id));
            Assert.NotNull(result);
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
        public async Task TestGetServerActionHistory()
        {
            var servers = CheckSuccess(await Client.IaaS.GetServerList());
            // Assuming there is at least one server present and returned
            Assert.NotNull(servers);
            Assert.NotNull(servers.Data);
            Assert.NotEmpty(servers.Data);
            
            var result = CheckSuccess(await Client.IaaS.GetServerActionHistory(servers.Data[0].Id));
            Assert.NotNull(result);
        }

    }
}