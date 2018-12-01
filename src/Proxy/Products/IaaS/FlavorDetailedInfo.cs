using System.Collections.Generic;
using Newtonsoft.Json;

namespace Arvan.Proxy.Products.IaaS
{
    public class FlavorDetailedInfo
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        [JsonProperty("disk")]
        public int? DiskGb { get; set; }

        [JsonProperty("ram")]
        public int? MemoryMb { get; set; }
        
        public string Swap { get; set; }
        
        [JsonProperty("vcpus")]
        public int? VCpuCount { get; set; }
        
        public List<LinkDetailedInfo> Links { get; set; }
        
        [JsonProperty("OS-FLV-DISABLED:disabled")]
        public bool? IsDisabled { get; set; }
        
        [JsonProperty("os-flavor-access:is_public")]
        public bool? IsPublic { get; set; }
        
        [JsonProperty("rxtx_factor")]
        public int? RxTxFactor { get; set; }
        
        [JsonProperty("OS-FLV-EXT-DATA:ephemeral")]
        public int? Ephemeral { get; set; }
    }
}