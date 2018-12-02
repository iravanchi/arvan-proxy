using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Arvan.Proxy.Products.IaaS
{
    public class SecurityGroupDetailedRuleInfo
    {
        public string Id { get; set; }
        
        public string SecurityGroupId { get; set; }
        
        public string TenantId { get; set; }
        
        [JsonProperty("project_id")]
        public string ProjectId { get; set; }
        
        public string Description { get; set; }
        
        public List<string> Tags { get; set; }
        
        public string Direction { get; set; }
        
        public string EtherType { get; set; }
        
        public int? PortRangeMin { get; set; }
        
        public int? PortRangeMax { get; set; }
        
        public string Protocol { get; set; }
        
        public string RemoteGroupId { get; set; }
        
        public string RemoteIpPrefix { get; set; }
        
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        [JsonProperty("revision_number")]
        public int RevisionNumber { get; set; }
    }
}