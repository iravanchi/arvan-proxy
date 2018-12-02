using System.Collections.Generic;
using Newtonsoft.Json;

namespace Arvan.Proxy.Products.IaaS
{
    public class GetServerCreationOptionsResponse
    {
        [JsonProperty("message_bags")]
        public Dictionary<string, string> MessageBags { get; set; }
        
        public ServerCreationOptionsInfo Data { get; set; }
    }
}