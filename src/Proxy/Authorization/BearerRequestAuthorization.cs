using System.Net.Http;
using System.Net.Http.Headers;

namespace Arvan.Proxy.Authorization
{
    public class BearerRequestAuthorization : RequestAuthorizationBase
    {
        private readonly string _bearer;

        public BearerRequestAuthorization(string bearer)
        {
            _bearer = bearer;
        }
        
        public override void Apply(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _bearer);
        }

    }
}