using System.Net.Http;

namespace Arvan.Proxy.Authorization
{
    public class NullRequestAuthorization : RequestAuthorizationBase
    {
        public override void Apply(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.Authorization = null;
        }
    }
}