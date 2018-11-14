using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Arvan.Proxy.Products.IaaS
{
    public class GetFloatingIpListResponse
    {
        public List<FloatingIpInfo> Data { get; set; }
    }
}