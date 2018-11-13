using System.Threading.Tasks;
using Arvan.Proxy.Tests.Base;
using Xunit;

namespace Arvan.Proxy.Tests.IaaS
{
    public class GetFloatingIpListTests : ArvanProxyTestBase
    {
        [Fact]
        public async Task CheckInvocationWithoutErrors()
        {
            var result = await Client.IaaS.GetFloatIpList();
            
            Assert.NotNull(result);
        }
    }
}