using System;
using Newtonsoft.Json;

namespace Arvan.Proxy.Products.IaaS
{
    public class ServerActionHistoryItem
    {
        [JsonProperty("instance_uuid")]
        public string InstanceId { get; set; }
        
        [JsonProperty("start_time")]
        public DateTime StartedAt { get; set; }
        
        public string Action { get; set; }
        
        public string Message { get; set; }
    }
}