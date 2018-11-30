using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Hydrogen.General.Utils;
using Hydrogen.General.Validation;
using Newtonsoft.Json;

namespace Arvan.Proxy.Utils
{
    public static class ResponseMessageExtensions
    {
        public static async Task<ApiValidationResult> ToValidationResult(this HttpResponseMessage response)
        {
            return response.IsSuccessStatusCode
                ? ApiValidationResult.Ok()
                : await response.DeserializeFailureAsync();
        }

        public static async Task<ApiValidatedResult<TResponse>> ToValidatedResult<TResponse>(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var content = await response.DeserializeSuccessAsync<TResponse>();
                return ApiValidatedResult<TResponse>.Ok(content);
            }

            return await response.DeserializeFailureAsync<TResponse>();
        }

        public static async Task<ApiValidatedResult<string>> ToRawValidatedResult(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return ApiValidatedResult<string>.Ok(content);
            }

            return ApiValidatedResult<string>.Failure(await response.Content.ReadAsStringAsync());
        }

        public static async Task<T> DeserializeSuccessAsync<T>(this HttpResponseMessage self)
        {
            if (!self.IsSuccessStatusCode)
            {
                throw new ArgumentException($@"HttpResponseMessage is unsuccessful with status code {self.StatusCode} {self.ReasonPhrase}. Cannot deserialize an instance of type {typeof(T).FullName}.");
            }

            try
            {
                var serializedContent = await self.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<T>(serializedContent);

                return value;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($@"Error occured while trying to convert HttpResponseMessage to {typeof(T).FullName}", e);
            }
        }
        
        public static async Task<ApiValidationResult> DeserializeFailureAsync(this HttpResponseMessage self)
        {
            ApiValidationResult result = null;
            ApiValidationError deserializationError = null;
            try
            {
                var serializedContent = await self.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ApiValidationResult>(serializedContent);
            }
            catch (Exception e)
            {
                deserializationError = new ApiValidationError(e.GetType().Name, e.Message.Yield());
            }
            
            if (result == null)
                result = new ApiValidationResult();
            
            if (result.Errors == null)
                result.Errors = new List<ApiValidationError>();
            
            result.Errors.Add(new ApiValidationError(self.StatusCode.ToString(), self.ReasonPhrase.Yield()));
            if (deserializationError != null)
                result.Errors.Add(deserializationError);

            result.Success = false;
            return result;
        }
        
        public static async Task<ApiValidatedResult<T>> DeserializeFailureAsync<T>(this HttpResponseMessage self)
        {
            ApiValidatedResult<T> result = null;
            ApiValidationError deserializationError = null;
            try
            {
                var serializedContent = await self.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ApiValidatedResult<T>>(serializedContent);
            }
            catch (Exception e)
            {
                deserializationError = new ApiValidationError(e.GetType().Name, e.Message.Yield());
            }
            
            if (result == null)
                result = new ApiValidatedResult<T>();
            
            if (result.Errors == null)
                result.Errors = new List<ApiValidationError>();
            
            result.Errors.Add(new ApiValidationError(self.StatusCode.ToString(), self.ReasonPhrase.Yield()));
            if (deserializationError != null)
                result.Errors.Add(deserializationError);

            result.Success = false;
            return result;
        }
    }
}