using System.Text.Json.Serialization;

namespace ChatGPT.Models
{
    public class RequestModel
    {
        [JsonPropertyName("model")]
        public string ModelId { get; set; } = "";

        [JsonPropertyName("messages")]
        public List<MessageModel> Messages { get; set; } = new();
    }
}
