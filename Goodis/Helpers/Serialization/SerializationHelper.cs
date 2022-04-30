using System.Text.Json;
using System.Text.Json.Serialization;

namespace Goodis.Helpers.Serialization
{
    public static class SerializationHelper
    {
        public static T RemoveNulls<T>(this T res)
        {
            JsonSerializerOptions opt = new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull};
            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(res, opt));
        }
    }
}
