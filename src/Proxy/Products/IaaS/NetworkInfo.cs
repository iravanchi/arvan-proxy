using Newtonsoft.Json;

namespace Arvan.Proxy.Products.IaaS
{
    public class NetworkInfo
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public bool? Default { get; set; }
        
        [JsonProperty("$isDisabled")]
        public bool? IsDisabled { get; set; }
    }
}