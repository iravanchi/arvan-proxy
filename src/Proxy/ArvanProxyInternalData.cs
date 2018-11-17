using System;
using System.Net.Http;

namespace Arvan.Proxy
{
    public class ArvanProxyInternalData
    {
        public ArvanClient ClientInstance { get; set; }
        public ArvanClientSettings Settings { get; set; }
        
        public HttpClient HttpClient { get; set; }
        public Uri BaseUri { get; set; }
    }
}