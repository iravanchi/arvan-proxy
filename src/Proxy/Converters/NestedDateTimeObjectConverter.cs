using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Arvan.Proxy.Converters
{
    public class NestedDateTimeObjectConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Not implemented yet");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject obj = JObject.Load(reader);

            if (DateTime.TryParse(obj["date"].ToString(), out var result))
                return result;
            
            // TODO: Consider the timezone
            // Sample:
            //       "created_at":{
            //          "date":"2018-10-21 10:17:34.000000",
            //          "timezone_type":2,
            //          "timezone":"Z"
            //       },
            
            throw new FormatException();
        }

        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
}