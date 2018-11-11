using System.Net.Http;

namespace Arvan.Proxy.Common
{
    public class ArvanProxyInternalData
    {
        public ArvanProxySettings Settings { get; set; }
        public HttpClient HttpClient { get; set; }
    }
}