using System.Threading.Tasks;
using Arvan.Proxy.Tests.Base;
using Xunit;

namespace Arvan.Proxy.Tests.IaaS
{
    public class ImageTests : ArvanProxyTestBase
    {
        [Fact]
        public async Task TestListingAllFloatingIps()
        {
            var result = CheckSuccess(await Client.IaaS.GetImageList());
            Assert.NotNull(result);
        }
    }
}