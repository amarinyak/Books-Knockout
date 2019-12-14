using Books.BL.Interfaces.Serializers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Books.BL.Serializers
{
    public class JsonSerializer : ISerializer
    {
        private readonly JsonSerializerSettings _serializerSettings;

        public JsonSerializer()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            };
        }

        public string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value, _serializerSettings);
        }
    }
}
