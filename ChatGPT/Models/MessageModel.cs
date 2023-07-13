using System.Text.Json.Serialization;

namespace ChatGPT.Models
{
    public class MessageModel
    {
        [JsonPropertyName("role")]
        public string Role { get; set; } = "";

        [JsonPropertyName("content")]
        public string Content { get; set; } = "";
    }
}
