using System.Text.Json.Serialization;
using OpenAI.Chat;

namespace ChatGpt.Models.WebModels
{
    public class UserInputRequest
    {
        [JsonPropertyName("userInput")]
        public required string UserInput { get; set; }
        [JsonPropertyName("systemInput")]
        public string? SystemInput { get; set; } = null;
        [JsonPropertyName("chatGptModel")]
        public string? ChatGptModel { get; set; } = null;
        [JsonPropertyName("previousResponseId")]
        public string? PreviousResponseId { get; set; } = null;
    }

    public class UserInputResponse
    {
        public required string Text { get; set; } = string.Empty;
        public string? PreviousResponseId { get; set; } = null;
        public string  UsageToken {  get; set; } = string.Empty;
    }

    public class UserInputRequestRequestPayload
    {
        [JsonPropertyName("model")]
        public string Model { get; set; } = string.Empty;

        [JsonPropertyName("input")]
        public IList<InputPayload> Input  { get; set; } = [];

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("previous_response_id")]
        public string? PreviousResponseId { get; set; } = null;
    }

    public class InputPayload
    {
        [JsonPropertyName("role")]
        public string Role { get; set; } = string.Empty;
        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;
        public static InputPayload CreateSystemMessage(string content)
        {
            return new InputPayload { Role = "system", Content = content };
        }
        public static InputPayload CreateUserMessage(string content)
        {
            return new InputPayload { Role = "user", Content = content };
        }
    }
}
