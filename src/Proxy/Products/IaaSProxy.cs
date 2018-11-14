using System.Collections.Generic;
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
        
        public async Task<ApiValidatedResult<GetFloatingIpListResponse>> GetFloatingIpList()
        {
            var response = await GenericSendRequestAsync(HttpMethod.Get, "/iaas/v1/float-ip");
            return await response.ToValidatedResult<GetFloatingIpListResponse>();
        }

        public async Task<ApiValidatedResult<CreateFloatingIpResponse>> CreateFloatingIp(string description)
        {
            var response = await GenericSendRequestAsync(HttpMethod.Post, "/iaas/v1/float-ip",
                new Dictionary<string, string>
                {
                    {"description", description}
                });

            return await response.ToValidatedResult<CreateFloatingIpResponse>();
        }

        public async Task<ApiValidatedResult<DeleteFloatingIpResponse>> DeleteFloatingIp(string id)
        {
            var response = await GenericSendRequestAsync(HttpMethod.Delete, $"/iaas/v1/float-ip/{id}");
            return await response.ToValidatedResult<DeleteFloatingIpResponse>();
        }
        
        public async Task<ApiValidatedResult<string>> AttachFloatingIp(string id, string serverId, string subnetId)
        {
            var response = await GenericSendRequestAsync(new HttpMethod("PATCH"), $"/iaas/v1/float-ip/{id}/attach",
                new Dictionary<string, string>
                {
                    {"server_Id", serverId},
                    {"subnet_Id", subnetId}
                });

            return await response.ToRawValidatedResult();
        }
        
        public async Task<ApiValidatedResult<string>> DetachFloatingIp(string serverId)
        {
            var response = await GenericSendRequestAsync(new HttpMethod("PATCH"), $"/iaas/v1/float-ip/attach",
                new Dictionary<string, string>
                {
                    {"server_Id", serverId}
                });

            return await response.ToRawValidatedResult();
        }
    }
}