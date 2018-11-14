using System.Net.Http;

namespace Arvan.Proxy.Authorization
{
    public abstract class RequestAuthorizationBase
    {
        public abstract void Apply(HttpRequestMessage requestMessage);
    }
}