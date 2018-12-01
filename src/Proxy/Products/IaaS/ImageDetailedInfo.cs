using System;
using System.Collections.Generic;
using Arvan.Proxy.Converters;
using Newtonsoft.Json;

namespace Arvan.Proxy.Products.IaaS
{
    public class ImageDetailedInfo
    {
        public string Id { get; set; }

        public string Status { get; set; }

        public string Name { get; set; }

        public List<LinkDetailedInfo> Links { get; set; }

        public ImageMetadataInfo Metadata { get; set; }
        
        [JsonProperty("minDisk")]
        public int MinDiskGb { get; set; }
        
        [JsonProperty("minRam")]
        public int MinMemoryMb { get; set; }
        
        public int Progress { get; set; }
        
        [JsonConverter(typeof(NestedDateTimeObjectConverter))]
        [JsonProperty("created")]
        public DateTime CreatedAt { get; set; }
        
        [JsonConverter(typeof(NestedDateTimeObjectConverter))]
        [JsonProperty("updated")]
        public DateTime UpdatedAt { get; set; }
        
        [JsonProperty("OS-EXT-IMG-SIZE:size")]
        public long SizeBytes { get; set; }
    }
}