using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace System.Text.Json;

public static class JsonSerializerExtensions
{
    extension(JsonSerializer)
    {
        public static bool TryDeserialize<T>(string json, [NotNullWhen(true)] out T? value)
            where T : class
        {
            try
            {
                value = JsonSerializer.Deserialize<T>(json);
                return value is not null;
            }
            catch (JsonException)
            {
                value = null;
                return false;
            }
        }
    }
}
