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
            var result = await Client.IaaS.GetFloatingIpList();
            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestCreatingAndRemovingNewFloatingIp()
        {
            var createResult = await Client.IaaS.CreateFloatingIp("From arvan-proxy unit tests");
            Assert.NotNull(createResult);
            Assert.True(createResult.Success);

            var deleteResult = await Client.IaaS.DeleteFloatingIp(createResult.Result.Data.Id);
            Assert.NotNull(deleteResult);
            Assert.True(deleteResult.Success);
        }
    }
}