using System.Net.Http;

namespace Arvan.Proxy
{
    public class ArvanProxyInternalData
    {
        public ArvanProxySettings Settings { get; set; }
        public HttpClient HttpClient { get; set; }
    }
}