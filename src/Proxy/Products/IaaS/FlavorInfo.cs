using Newtonsoft.Json;

namespace Arvan.Proxy.Products.IaaS
{
    public class FlavorInfo
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        [JsonProperty("cpu_count")]
        public int CpuCount { get; set; }
        
        [JsonProperty("disk")]
        public int DiskGb { get; set; }
        
        [JsonProperty("disk_in_bytes")]
        public long DiskBytes { get; set; }
        
        [JsonProperty("bandwidth_in_bytes")]
        public long BandwidthBytes { get; set; }
        
        [JsonProperty("memory")]
        public int MemoryGb { get; set; }
        
        [JsonProperty("memory_in_bytes")]
        public long MemoryBytes { get; set; }
        
        [JsonProperty("price_per_hour")]
        public long PricePerHour { get; set; }
        
        [JsonProperty("price_per_month")]
        public long PricePerMonth { get; set; }
        
        public string Type { get; set; }
        
        public string Order { get; set; }
    }
}