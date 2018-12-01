using System;
using System.Collections.Generic;
using Arvan.Proxy.Converters;
using Newtonsoft.Json;

namespace Arvan.Proxy.Products.IaaS
{
    public class ServerDetailedInfo
    {
        public string Id { get; set; }
        public Dictionary<string, List<AddressInfo>> Addresses { get; set; }
        
        [JsonProperty("created")]
        [JsonConverter(typeof(NestedDateTimeObjectConverter))]
        public DateTime CreatedAt { get; set; }
        
        public FlavorDetailedInfo Flavor { get; set; }
        
        public ImageDetailedInfo Image { get; set; }
        
        public string Name { get; set; }
        
        public List<SecurityGroupInfo> SecurityGroups { get; set; }
        
        [JsonProperty("task_state")]
        public string TaskState { get; set; }
        
        public string Status { get; set; }
        
        [JsonProperty("key_name")]
        public string KeyName { get; set; }
        
        public string Password { get; set; }

        [JsonProperty("ar_next")]
        public string ArNext { get; set; }
    }
}