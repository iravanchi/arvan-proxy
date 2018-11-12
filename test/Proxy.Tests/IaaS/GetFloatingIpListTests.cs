using System.Threading.Tasks;
using Xunit;

namespace Arvan.Proxy.Tests.IaaS
{
    public class GetFloatingIpListTests
    {
        [Fact]
        public async Task CheckInvocationWithoutErrors()
        {
            var arvan = new ArvanClient();
            var result = await arvan.IaaS.GetFloatIpList();
            
            Assert.NotNull(result);
        }
    }
}