using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Arvan.Proxy.Products.IaaS;
using Arvan.Proxy.Utils;
using Hydrogen.General.Text;
using Hydrogen.General.Validation;

namespace Arvan.Proxy.Products
{
    public class IaaSProxy : ArvanProxyBase
    {
        internal IaaSProxy(ArvanProxyInternalData internalData) : base(internalData)
        {
        }

        #region General

        public async Task<ApiValidatedResult<string>> GetQuota()
        {
            var response = await GenericSendRequestAsync(HttpMethod.Get, "/iaas/v1/project/quota");
            return await response.ToRawValidatedResult();
        }
        
        #endregion

        #region Floating IP

        public async Task<ApiValidatedResult<GetFloatingIpListResponse>> GetFloatingIpList()
        {
            var response = await GenericSendRequestAsync(HttpMethod.Get, "/iaas/v1/float-ip");
            return await response.ToValidatedResult<GetFloatingIpListResponse>();
        }

        public async Task<ApiValidatedResult<CreateFloatingIpResponse>> CreateFloatingIp(string description)
        {
            var response = await GenericSendRequestAsync(
                HttpMethod.Post, "/iaas/v1/float-ip",
                formDataRequestBody: new Dictionary<string, string>
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
            var response = await GenericSendRequestAsync(
                new HttpMethod("PATCH"), $"/iaas/v1/float-ip/{id}/attach",
                formDataRequestBody: new Dictionary<string, string>
                {
                    {"server_Id", serverId},
                    {"subnet_Id", subnetId}
                });

            return await response.ToRawValidatedResult();
        }
        
        public async Task<ApiValidatedResult<string>> DetachFloatingIp(string serverId)
        {
            var response = await GenericSendRequestAsync(
                new HttpMethod("PATCH"), "/iaas/v1/float-ip/detach",
                formDataRequestBody: new Dictionary<string, string>
                {
                    {"server_Id", serverId}
                });

            return await response.ToRawValidatedResult();
        }

        #endregion
        
        #region Image
        
        public async Task<ApiValidatedResult<GetImageListResponse>> GetImageList(ImageType? type = null, int? limit = null, string lastId = null)
        {
            var queryString = new Dictionary<string, string>();
            if (type.HasValue) queryString["type"] = type.Value.ToString().ToLower();
            if (limit.HasValue) queryString["limit"] = limit.Value.ToString();
            if (!lastId.IsNullOrWhitespace()) queryString["lastId"] = lastId;
            
            var response = await GenericSendRequestAsync(HttpMethod.Get, "/iaas/v1/image", queryString);
            return await response.ToValidatedResult<GetImageListResponse>();
        }

        public Task<ApiValidatedResult<string>> DeleteImage(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiValidatedResult<string>> UploadImage(Stream contents, string name, int MinDiskGb, int MinRamGb)
        {
            throw new NotImplementedException();
        }
        
        #endregion

        #region Network

        public Task<ApiValidatedResult<string>> GetNetworkList()
        {
            throw new NotImplementedException();
        }

        public async Task<ApiValidatedResult<string>> GetPortList()
        {
            var response = await GenericSendRequestAsync(HttpMethod.Get, "/iaas/v1/port");
            return await response.ToRawValidatedResult();
        }

        public Task<ApiValidatedResult<string>> CreateNetwork()
        {
            throw new NotImplementedException();
        }

        public Task<ApiValidatedResult<string>> AttachNetwork(string id, string serverId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiValidatedResult<string>> DetachNetwork(string id, string serverId)
        {
            throw new NotImplementedException();
        }

        #endregion
        
        #region SSH Key

        public async Task<ApiValidatedResult<string>> GetSshKeyList(int? limit = null, string lastId = null)
        {
            var queryString = new Dictionary<string, string>();
            if (limit.HasValue) queryString["limit"] = limit.Value.ToString();
            if (!lastId.IsNullOrWhitespace()) queryString["lastId"] = lastId;

            var response = await GenericSendRequestAsync(HttpMethod.Get, "/iaas/v1/project/quota", queryString);
            return await response.ToRawValidatedResult();
        }

        public Task<ApiValidatedResult<string>> UploadNewSshKey()
        {
            throw new NotImplementedException();
        }

        public async Task<ApiValidatedResult<string>> GenerateNewSshKey()
        {
            var response = await GenericSendRequestAsync(HttpMethod.Get, "/iaas/v1/ssh-key/generate");
            return await response.ToRawValidatedResult();

        }

        public Task<ApiValidatedResult<string>> DeleteSshKey(string name)
        {
            throw new NotImplementedException();
        }
        
        #endregion
        
        #region Security Groups

        public async Task<ApiValidatedResult<string>> GetSecurityGroupList()
        {
            var response = await GenericSendRequestAsync(HttpMethod.Get, "/iaas/v1/security");
            return await response.ToRawValidatedResult();
        }

        public Task<ApiValidatedResult<string>> CreateSecurityGroup(string name, string description)
        {
            throw new NotImplementedException();
        }

        public Task<ApiValidatedResult<string>> DeleteSecurityGroup(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiValidatedResult<string>> GetSecurityGroupRuleList(string securityGroupId)
        {
            var response = await GenericSendRequestAsync(HttpMethod.Get, $"/iaas/v1/security-rules/{securityGroupId}");
            return await response.ToRawValidatedResult();
        }

        public Task<ApiValidatedResult<string>> CreateSecurityGroupRule(string securityGroupId, string direction,
            int portFrom, int portTo, string protocol, string ips, string description)
        {
            throw new NotImplementedException();
        }

        public Task<ApiValidatedResult<string>> DeleteSecurityGroupRule(string securityGroupId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiValidatedResult<string>> AddSecurityGroupToServer(string serverId, string securityGroupId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiValidatedResult<string>> RemoveSecurityGroupFromServer(string serverId, string securityGroupId)
        {
            throw new NotImplementedException();
        }
        
        #endregion
        
        #region Server

        public async Task<ApiValidatedResult<GetServerListResponse>> GetServerList(int? limit = null, 
            string lastId = null, string with = null)
        {
            var queryString = new Dictionary<string, string>();
            if (limit.HasValue) queryString["limit"] = limit.Value.ToString();
            if (!lastId.IsNullOrWhitespace()) queryString["lastId"] = lastId;
            if (!with.IsNullOrWhitespace()) queryString["with"] = with;

            var response = await GenericSendRequestAsync(HttpMethod.Get, "/iaas/v1/server", queryString);
            return await response.ToValidatedResult<GetServerListResponse>();
        }

        public async Task<ApiValidatedResult<string>> GetDetailedServerList(int? limit = null, string lastId = null,
            string with = null)
        {
            var queryString = new Dictionary<string, string>();
            queryString["detailed"] = "true";
            if (limit.HasValue) queryString["limit"] = limit.Value.ToString();
            if (!lastId.IsNullOrWhitespace()) queryString["lastId"] = lastId;
            if (!with.IsNullOrWhitespace()) queryString["with"] = with;

            var response = await GenericSendRequestAsync(HttpMethod.Get, "/iaas/v1/server", queryString);
            return await response.ToRawValidatedResult();
        }

        public async Task<ApiValidatedResult<string>> GetServerDetails(string serverId)
        {
            var response = await GenericSendRequestAsync(HttpMethod.Get, $"/iaas/v1/server/{serverId}");
            return await response.ToRawValidatedResult();
        }

        public async Task<ApiValidatedResult<string>> GetServerVncConsole(string serverId)
        {
            var response = await GenericSendRequestAsync(HttpMethod.Get, $"/iaas/v1/server/{serverId}/vnc");
            return await response.ToRawValidatedResult();
        }
        
        public async Task<ApiValidatedResult<string>> GetServerCreationOptions()
        {
            var response = await GenericSendRequestAsync(HttpMethod.Get, "/iaas/v1/server/options_for_create");
            return await response.ToRawValidatedResult();
        }

        public async Task<ApiValidatedResult<string>> GetServerFlavorList()
        {
            var response = await GenericSendRequestAsync(HttpMethod.Get, "/iaas/v1/size");
            return await response.ToRawValidatedResult();
        }
        
        public Task<ApiValidatedResult<string>> CreateServer(string name, string flavorId, string imageId,
            string networkId, string[] securityGroups, string sshKeyName = null, int count = 1)
        {
            throw new NotImplementedException();
        }

        public Task<ApiValidatedResult<string>> DeleteServer(string serverId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiValidatedResult<string>> GetServerActionsList(string serverId)
        {
            var response = await GenericSendRequestAsync(HttpMethod.Get, $"/iaas/v1/server/{serverId}/action");
            return await response.ToRawValidatedResult();
        }

        public Task<ApiValidatedResult<string>> RequestServerAction(string serverId, ServerAction action)
        {
            throw new NotImplementedException();
        }
        
        #endregion
        
        #region Subnets
        
        public async Task<ApiValidatedResult<string>> GetSubnetList()
        {
            var response = await GenericSendRequestAsync(HttpMethod.Get, "/iaas/v1/subnet");
            return await response.ToRawValidatedResult();
        }

        public Task<ApiValidatedResult<string>> CreateSubnet()
        {
            throw new NotImplementedException();
        }

        public Task<ApiValidatedResult<string>> UpdateSubnet(string subnetId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiValidatedResult<string>> DeleteSubnet(string subnetId)
        {
            throw new NotImplementedException();
        }
        
        #endregion
        
        #region Volumes

        public async Task<ApiValidatedResult<string>> GetVolumeList()
        {
            var response = await GenericSendRequestAsync(HttpMethod.Get, "/iaas/v1/volume");
            return await response.ToRawValidatedResult();
        }

        public async Task<ApiValidatedResult<string>> GetVolumeLimits()
        {
            var response = await GenericSendRequestAsync(HttpMethod.Get, "/iaas/v1/volume/limits");
            return await response.ToRawValidatedResult();
        }

        public async Task<ApiValidatedResult<string>> GetVolumeDetails(string volumeId)
        {
            var response = await GenericSendRequestAsync(HttpMethod.Get, $"/iaas/v1/volume/{volumeId}");
            return await response.ToRawValidatedResult();
        }
        
        public Task<ApiValidatedResult<string>> CreateVolume(string name, int SizeGb, string description)
        {
            throw new NotImplementedException();
        }

        public Task<ApiValidatedResult<string>> AttachVolume(string volumeId, string serverId)
        {
            throw new NotImplementedException();
        }
        
        public Task<ApiValidatedResult<string>> DetachVolume(string volumeId, string serverId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiValidatedResult<string>> UpdateVolume(string volumeId)
        {
            throw new NotImplementedException();
        }
        
        public Task<ApiValidatedResult<string>> DeleteVolume(string volumeId)
        {
            throw new NotImplementedException();
        }
        
        #endregion
        
    }
}