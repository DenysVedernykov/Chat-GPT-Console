using ChatGPT.Models;
using System.Linq;
using System.Net.Http.Json;

string apiKey = "token";

string endpoint = "https://api.openai.com/v1/chat/completions";

var messages = new List<MessageModel>();

var httpClient = new HttpClient();

httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

while (true)
{
    Console.Write("User: ");

    var content = Console.ReadLine();

    if (content is not { Length: > 0 })
    {
        break;
    }

    var message = new MessageModel()
    {
        Role = "user",
        Content = content
    };

    messages.Add(message);

    var requestData = new RequestModel()
    {
        ModelId = "gpt-3.5-turbo",
        Messages = messages
    };

    using var response = await httpClient.PostAsJsonAsync(endpoint, requestData);

    if (!response.IsSuccessStatusCode)
    {
        Console.WriteLine($"{(int)response.StatusCode} {response.StatusCode}");
        break;
    }

    var responseData = await response.Content.ReadFromJsonAsync<ResponseDataModel>();

    var choices = responseData?.Choices ?? new List<ChoiceModel>();

    if (choices.Count == 0)
    {
        Console.WriteLine("No choices were returned by the API");
        continue;
    }

    var choice = choices[0];
    var responseMessage = choice.Message;

    messages.Add(responseMessage);

    var responseText = responseMessage.Content.Trim();

    Console.WriteLine($"ChatGPT: {responseText}");
}