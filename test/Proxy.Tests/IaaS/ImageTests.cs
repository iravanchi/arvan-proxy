using System.Threading.Tasks;
using Arvan.Proxy.Products.IaaS;
using Arvan.Proxy.Tests.Base;
using Xunit;

namespace Arvan.Proxy.Tests.IaaS
{
    public class ImageTests : ArvanProxyTestBase
    {
        [Fact]
        public async Task TestListingAllImages()
        {
            var result = CheckSuccess(await Client.IaaS.GetImageList());
            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task TestListingImagesByType()
        {
            var serverImages = CheckSuccess(await Client.IaaS.GetImageList(ImageType.Server));
            Assert.NotNull(serverImages);
            
            var snapshots = CheckSuccess(await Client.IaaS.GetImageList(ImageType.Snapshot));
            Assert.NotNull(snapshots);
        }
    }
}