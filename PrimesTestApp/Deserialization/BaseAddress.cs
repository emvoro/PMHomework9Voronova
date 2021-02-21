using System.Text.Json.Serialization;

namespace PrimesTestApp.Deserialization
{
    public class BaseAddress
    {
        [JsonPropertyName("baseAddress")]
        public string Address { get; set; }
    }
}
