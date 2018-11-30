using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Arvan.Proxy.Utils;
using Hydrogen.General.Text;
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

        protected async Task<HttpResponseMessage> GenericSendRequestAsync(HttpMethod method, string relativeUri, 
            IEnumerable<KeyValuePair<string, string>> queryString = null, object jsonRequestBody = null, 
            IEnumerable<KeyValuePair<string, string>> formDataRequestBody = null)
        {
            HttpContent content = null;
                
            if (relativeUri.IsNullOrWhitespace())
                throw new ArgumentNullException(nameof(relativeUri));
            if (jsonRequestBody != null && formDataRequestBody != null)
                throw new ArgumentException("Cannot set FormData and JSON at the same time.");

            if (jsonRequestBody!= null)
                content = new StringContent(JsonConvert.SerializeObject(jsonRequestBody), Encoding.UTF8, "application/json");
            if (formDataRequestBody != null)
                content = new FormUrlEncodedContent(formDataRequestBody);

            var uri = new Uri(_internalData.BaseUri, relativeUri).AddQueries(queryString);
            var payload = new HttpRequestMessage(method, uri) {Content = content};
            payload.Headers.Accept.Clear();
            payload.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _internalData.Settings.RequestAuthorization?.Apply(payload);

            var response = await _internalData.HttpClient.SendAsync(payload);
            ThrowOnErrorIfRequired(response);
            return response;
        }

        private void ThrowOnErrorIfRequired(HttpResponseMessage response)
        {
            if (_internalData.Settings.ThrowOnErrorStatusCode)
                response.EnsureSuccessStatusCode();
        }
    }
}