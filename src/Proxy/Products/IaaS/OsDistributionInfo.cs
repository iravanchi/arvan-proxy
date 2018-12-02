using System.Collections.Generic;

namespace Arvan.Proxy.Products.IaaS
{
    public class OsDistributionInfo
    {
        public string Name { get; set; }
        
        public List<OsDistributionImageInfo> Images { get; set; }
    }
}