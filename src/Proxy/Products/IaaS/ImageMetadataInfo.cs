using Newtonsoft.Json;

namespace Arvan.Proxy.Products.IaaS
{
    public class ImageMetadataInfo
    {
        public string Username { get; set; }
        
        public string ArVisibility { get; set; }
        
        [JsonProperty("ssh_key")]
        public string SshKey { get; set; }
        
        [JsonProperty("ssh_password")]
        public string SshPassword { get; set; }
        
        [JsonProperty("os_type")]
        public string OsType { get; set; }
        
        public string OsVersion { get; set; }
        
        public string Os { get; set; }
        
        [JsonProperty("hw_disk_bus")]
        public string HwDiskBus { get; set; }
    }
}