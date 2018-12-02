using Newtonsoft.Json;

namespace Arvan.Proxy.Products.IaaS
{
    public class OsDistributionImageInfo
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        [JsonProperty("distribution_name")]
        public string DistributionName { get; set; }
        
        [JsonProperty("disk")]
        public int DiskGb { get; set; }
        
        [JsonProperty("ram")]
        public int MemoryMb { get; set; }
        
        [JsonProperty("ssh_key")]
        public bool SshKey { get; set; }
        
        [JsonProperty("ssh_password")]
        public bool SshPassword { get; set; }
    }
}