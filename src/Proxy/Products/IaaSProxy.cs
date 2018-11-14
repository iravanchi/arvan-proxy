using System.Net.Http;
using System.Threading.Tasks;
using Arvan.Proxy.Products.IaaS;
using Arvan.Proxy.Utils;
using Hydrogen.General.Validation;

namespace Arvan.Proxy.Products
{
    public class IaaSProxy : ArvanProxyBase
    {
        internal IaaSProxy(ArvanProxyInternalData internalData) : base(internalData)
        {
        }
        
        public async Task<ApiValidatedResult<GetFloatIpListResponse>> GetFloatIpList()
        {
            var response = await GenericSendRequestAsync(HttpMethod.Get, "/iaas/v1/float-ip");
            return await response.ToValidatedResult<GetFloatIpListResponse>();
        }

        public async Task<ApiValidationResult> CreateFloatingIp(string description)
        {
            var response = await GenericSendRequestAsync(HttpMethod.Post, "/iaas/v1/float-ip", new
            {
                Description = description
            });

            return response.ToValidationResult();
        }

        public async Task<ApiValidationResult> DeleteFloatingIp(string id)
        {
            var response = await GenericSendRequestAsync(HttpMethod.Delete, $"/iaas/v1/float-ip/{id}");
            return response.ToValidationResult();
        }
        
        public async Task<ApiValidationResult> AttachFloatingIp(string id, string serverId, string subnetId)
        {
            var response = await GenericSendRequestAsync(new HttpMethod("PATCH"), $"/iaas/v1/float-ip/{id}/attach", new
            {
                Server_Id = serverId,
                Subnet_Id = subnetId
            });

            return response.ToValidationResult();
        }
        
        public async Task<ApiValidationResult> DetachFloatingIp(string serverId)
        {
            var response = await GenericSendRequestAsync(new HttpMethod("PATCH"), $"/iaas/v1/float-ip/attach", new
            {
                Server_Id = serverId
            });

            return response.ToValidationResult();
        }
    }
}