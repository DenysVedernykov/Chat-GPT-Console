using System.Text.Json.Serialization;

namespace ChatGPT.Models
{
    public class ResponseDataModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        [JsonPropertyName("object")]
        public string Object { get; set; } = "";

        [JsonPropertyName("created")]
        public ulong Created { get; set; }

        [JsonPropertyName("choices")]
        public List<ChoiceModel> Choices { get; set; } = new();

        [JsonPropertyName("usage")]
        public UsageModel Usage { get; set; } = new();
    }
}
