using Newtonsoft.Json;

namespace Arvan.Proxy.Products.IaaS
{
    public class ServerCreationInitialStateInfo
    {
        [JsonProperty("image_id")]
        public string ImageId { get; set; }
        
        [JsonProperty("size_id")]
        public string SizeId { get; set; }
        
        [JsonProperty("region_id")]
        public int? RegionId { get; set; }
        
        [JsonProperty("requires_payment_method")]
        public bool? RequiresPaymentMethod { get; set; }
        
        [JsonProperty("droplet_count")]
        public int? DropletCount { get; set; }
        
        [JsonProperty("droplet_limit")]
        public int? DropletLimit { get; set; }
    }
}