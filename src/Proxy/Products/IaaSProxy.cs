using System.Net.Http;
using System.Threading.Tasks;

namespace Arvan.Proxy.Products
{
    public class IaaSProxy : ArvanProxyBase
    {
        internal IaaSProxy(ArvanProxyInternalData internalData) : base(internalData)
        {
        }
        
        public async Task<string> GetFloatIpList()
        {
            var response = await GenericSendRequestAsync(HttpMethod.Get, "/iaas/v1/float-ip");
            return await response.Content.ReadAsStringAsync();
//            return await response.DeserializeAsync<GetJobListResponse>();
        }
    }
}