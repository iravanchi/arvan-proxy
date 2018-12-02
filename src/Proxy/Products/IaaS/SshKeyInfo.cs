using System;
using Arvan.Proxy.Converters;
using Newtonsoft.Json;

namespace Arvan.Proxy.Products.IaaS
{
    public class SshKeyInfo
    {
        public int Id { get; set; }
        
        public bool Checked { get; set; }
        
        public string Content { get; set; }
        
        public string Name { get; set; }
        
        public string Fingerprint { get; set; }
        
        [JsonConverter(typeof(NestedDateTimeObjectConverter))]
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}