using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Arvan.Proxy.Products.IaaS
{
    public class FloatingIpInfo
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string FloatingNetworkId { get; set; }
        public string RouterId { get; set; }
        public string FixedIpAddress { get; set; }
        public string FloatingIpAddress { get; set; }
        public string PortId { get; set; }
        public string Description { get; set; }
        
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        [JsonProperty("revision_number")]
        public int RevisionNumber { get; set; }
        
        public string Server { get; set; }
        public List<string> Tags { get; set; }
    }
}