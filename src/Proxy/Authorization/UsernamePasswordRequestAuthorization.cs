using System.Net.Http;
using System.Net.Http.Headers;
using Hydrogen.General.Text;

namespace Arvan.Proxy.Authorization
{
    public class UsernamePasswordRequestAuthorization : RequestAuthorizationBase
    {
        private readonly string _username;
        private readonly string _password;
        private string _bearer;

        public UsernamePasswordRequestAuthorization(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public override void Apply(HttpRequestMessage requestMessage)
        {
            EnsureBearerInitialized();
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _bearer);
        }

        private void EnsureBearerInitialized()
        {
            if (!_bearer.IsNullOrWhitespace())
                return;
            
            // TODO: Call authentication API endpoint
            _bearer = "bearer_from_auth_server";
        }
    }
}