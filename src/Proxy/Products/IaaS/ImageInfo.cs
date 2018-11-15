using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Arvan.Proxy.Products.IaaS
{
    public class ImageInfo
    {       
       public string Id { get; set; }
       
       public string Status { get; set; }
       
       public string Name { get; set; }
       
       [JsonProperty("min_ram")]
       public int MinRam { get; set; }
       
       [JsonProperty("min_disk")]
       public int MinDisk { get; set; }
       
       [JsonProperty("disk_format")]
       public string DiskFormat { get; set; }
       
       [JsonProperty("size")]
       public long SizeBytes { get; set; }
       
       public string Checksum { get; set; }
       
//       TODO: Conversion required
//       "created_at":{
//          "date":"2018-10-21 10:17:34.000000",
//          "timezone_type":2,
//          "timezone":"Z"
//       },
//       public DateTime CreatedOn { get; set; }
       
       [JsonProperty("container_format")]
       public string ContainerFormat { get; set; }

       public List<string> Tags { get; set; }

       [JsonProperty("ar_next")]
       public string ArNext { get; set; }
       
       [JsonProperty("image_type")]
       public string ImageType { get; set; }
    }
}