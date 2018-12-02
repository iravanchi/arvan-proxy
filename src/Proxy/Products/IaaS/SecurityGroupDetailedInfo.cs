using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Arvan.Proxy.Products.IaaS
{
    public class SecurityGroupDetailedInfo
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string TenantId { get; set; }
        
        public List<string> Tags { get; set; }
        
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        [JsonProperty("revision_number")]
        public int? RevisionNumber { get; set; }

        [JsonProperty("project_id")]
        public string ProjectId { get; set; }
        
        [JsonProperty("abraks")]
        public List<ServerSecurityGroupAssociationInfo> Servers { get; set; }
        
        [JsonProperty("securityGroupRules")]
        public List<SecurityGroupDetailedRuleInfo> Rules { get; set; }
    }
}