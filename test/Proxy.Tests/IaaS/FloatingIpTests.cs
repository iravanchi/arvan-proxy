using System;
using System.Linq;
using System.Threading.Tasks;
using Arvan.Proxy.Tests.Base;
using Xunit;

namespace Arvan.Proxy.Tests.IaaS
{
    public class FloatingIpTests : ArvanProxyTestBase
    {
        [Fact]
        public async Task TestListingAllFloatingIps()
        {
            var result = CheckSuccess(await Client.IaaS.GetFloatingIpList());
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task TestCreatingAndRemovingNewFloatingIp()
        {
            var description = "From arvan-proxy unit tests - " + Guid.NewGuid().ToString("N");
            
            var createResult = CheckSuccess(await Client.IaaS.CreateFloatingIp(description));
            Assert.NotNull(createResult.Data);
            Assert.False(string.IsNullOrWhiteSpace(createResult.Data.Id));
            Assert.Equal(description, createResult.Data.Description);
            Assert.Equal("DOWN", createResult.Data.Status);

            var deleteResult = CheckSuccess(await Client.IaaS.DeleteFloatingIp(createResult.Data.Id));
            Assert.NotNull(deleteResult);
            Assert.False(string.IsNullOrWhiteSpace(deleteResult.Message));
        }

        [Fact]
        public async Task TestCreatedAndDeletedFloatingIpInList()
        {
            var description = "From arvan-proxy unit tests - " + Guid.NewGuid().ToString("N");
            var id = CheckSuccess(await Client.IaaS.CreateFloatingIp(description)).Data.Id;

            var list = CheckSuccess(await Client.IaaS.GetFloatingIpList()).Data;
            var returnedItem = list.SingleOrDefault(i => i.Id == id);
            
            Assert.NotNull(returnedItem);
            Assert.Equal(description, returnedItem.Description);
            
            CheckSuccess(await Client.IaaS.DeleteFloatingIp(id));
        }

    }
}