using System.Net.Http;
using System.Net.Http.Headers;

namespace Arvan.Proxy.Authorization
{
    public class ApiKeyRequestAuthorization : RequestAuthorizationBase
    {
        private readonly string _apiKey;

        public ApiKeyRequestAuthorization(string apiKey)
        {
            _apiKey = apiKey;
        }
        
        public override void Apply(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Apikey", _apiKey);
        }
    }
}