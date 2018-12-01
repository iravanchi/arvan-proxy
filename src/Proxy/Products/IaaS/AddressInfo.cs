using Newtonsoft.Json;

namespace Arvan.Proxy.Products.IaaS
{
    public class AddressInfo
    {
        [JsonProperty("OS-EXT-IPS-MAC:mac_addr")]
        public string MacAddress { get; set; }
        
        [JsonProperty("addr")]
        public string IpAddress { get; set; }
        
        [JsonProperty("OS-EXT-IPS:type")]
        public string Type { get; set; }
        
        public int Version { get; set; }
    }
}