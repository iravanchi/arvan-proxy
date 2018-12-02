using System.Collections.Generic;
using Newtonsoft.Json;

namespace Arvan.Proxy.Products.IaaS
{
    public class IaasRegionInfo
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Slug { get; set; }
        
        public string Geography{ get; set; }
        
        public List<string> Restrictions { get; set; }
        
        public List<string> Features { get; set; }
        
        [JsonProperty("disabled_features")]
        public List<string> DisabledFeatures { get; set; }
        
        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }
    }
}