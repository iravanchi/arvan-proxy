using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Arvan.Proxy.Utils;
using Hydrogen.General.Text;
using Hydrogen.General.Validation;
using Newtonsoft.Json;

namespace Arvan.Proxy
{
    public class ArvanProxyBase
    {
        private readonly ArvanProxyInternalData _internalData;

        internal ArvanProxyBase(ArvanProxyInternalData internalData)
        {
            _internalData = internalData;
        }

        protected HttpClient HttpClient => _internalData.HttpClient;

        protected void ThrowOnErrorIfRequired(HttpResponseMessage response)
        {
            if (_internalData.Settings.ThrowOnErrorStatusCode)
                response.EnsureSuccessStatusCode();
        }

        protected async Task<HttpResponseMessage> GenericSendRequestAsync(HttpMethod method, string address,
            object request = null)
        {
            if (address.IsNullOrWhitespace())
                throw new ArgumentNullException(nameof(address));

            var payload = new HttpRequestMessage(method, address);
            
            if (request != null)
                payload.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await HttpClient.SendAsync(payload);
            ThrowOnErrorIfRequired(response);
            return response;
        }

        protected async Task<ApiValidatedResult<TResponse>> InternalSendRequest<TResponse>(HttpMethod method,
            string address, object request = null)
        {
            var response = await GenericSendRequestAsync(method, address, request);
            return await response.ToValidatedResult<TResponse>();
        }

        protected async Task<ApiValidationResult> InternalSendRequest(HttpMethod method, string address,
            object request = null)
        {
            var response = await GenericSendRequestAsync(method, address, request);
            return response.ToValidationResult();
        }
    }
}