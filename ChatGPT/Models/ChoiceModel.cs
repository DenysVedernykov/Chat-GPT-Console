using System.Text.Json.Serialization;

namespace ChatGPT.Models
{
    public class ChoiceModel
    {
        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("message")]
        public MessageModel Message { get; set; } = new();

        [JsonPropertyName("finish_reason")]
        public string FinishReason { get; set; } = "";
    }
}
