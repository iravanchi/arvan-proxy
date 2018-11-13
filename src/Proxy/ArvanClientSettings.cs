using Arvan.Proxy.Authorization;

namespace Arvan.Proxy
{
    public class ArvanClientSettings
    {
        public RequestAuthorizationBase RequestAuthorization { get; set; }
        public bool ThrowOnErrorStatusCode { get; set; } = false;
    }
}