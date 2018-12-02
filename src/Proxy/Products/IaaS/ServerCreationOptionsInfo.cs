using System.Collections.Generic;
using Newtonsoft.Json;

namespace Arvan.Proxy.Products.IaaS
{
    public class ServerCreationOptionsInfo
    {
        public List<FlavorInfo> Sizes { get; set; }
        
        public List<IaasRegionInfo> Regions { get; set; }
        
        public List<IaasFeatureInfo> Features { get; set; }
        
        public List<OsDistributionInfo> Distributions { get; set; }
        
        [JsonProperty("ssh_keys")]
        public List<SshKeyInfo> SshKeys { get; set; }
        
        public List<NetworkInfo> Networks { get; set; }
        
        [JsonProperty("initial_state")]
        public ServerCreationInitialStateInfo InitialState { get; set; }
        
        [JsonProperty("security_groups")]
        public List<SecurityGroupDetailedInfo> SecurityGroups { get; set; }
    }
}