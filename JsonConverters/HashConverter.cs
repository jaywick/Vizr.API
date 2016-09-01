using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizr.API.JsonConverters
{
    public class HashConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Hash);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var hashString = (string)reader.Value;

            if (String.IsNullOrWhiteSpace(hashString))
                return null;

            return Hash.Parse(hashString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var hash = (Hash)value;
            writer.WriteValue(hash.ToString());
            writer.Flush();
        }
    }
}
