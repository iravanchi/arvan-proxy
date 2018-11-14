using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Arvan.Proxy.Utils;
using Hydrogen.General.Text;
using Hydrogen.General.Validation;
using Newtonsoft.Json;

namespace Arvan.Proxy
{
    public abstract class ArvanProxyBase
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

        protected Task<HttpResponseMessage> GenericSendRequestAsync(HttpMethod method, string address)
        {
            return GenericSendRequestAsync(method, address, (HttpContent)null);
        }
        
        protected Task<HttpResponseMessage> GenericSendRequestAsync(HttpMethod method, string address, object request)
        {
            HttpContent content = null;
                
            if (request != null)
                content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            
            return GenericSendRequestAsync(method, address, content);
        }

        protected Task<HttpResponseMessage> GenericSendRequestAsync(HttpMethod method, string address, 
            IEnumerable<KeyValuePair<string, string>> formData)
        {
            HttpContent content = null;
                
            if (formData != null)
                content = new FormUrlEncodedContent(formData);
            
            return GenericSendRequestAsync(method, address, content);
        }

        protected async Task<HttpResponseMessage> GenericSendRequestAsync(HttpMethod method, string address, 
            HttpContent content)
        {
            if (address.IsNullOrWhitespace())
                throw new ArgumentNullException(nameof(address));

            var payload = new HttpRequestMessage(method, address) {Content = content};

            _internalData.Settings.RequestAuthorization?.Apply(payload);

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