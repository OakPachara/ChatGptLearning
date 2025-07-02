using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using ChatGpt.Models;
using ChatGpt.Models.OpenAIModels;
using ChatGpt.Models.WebModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OpenAI.Chat;

namespace ChatGpt.Controllers
{
    [Route("api/chat-gpt")]
    [ApiController]
    public class ChatGPTController(IOptions<AppSetting> appSetting) : ControllerBase
    {

        [HttpGet("complete-chat")]
        public async Task<string> CompleteChat(UserInputRequest userInput)
        {
            var client = new ChatClient(
                model: Commons.GetChatGptModel(userInput.ChatGptModel),
                apiKey: appSetting.Value.ChatGtpApiKey
            );
            var inputMessages = Commons.GetChatMessages(userInput.UserInput, userInput.SystemInput);

            ChatCompletion completion = await client.CompleteChatAsync(inputMessages);
            return completion.Content[0].Text;
        }


        [HttpPost("responses-api")]
        public async Task<UserInputResponse> ResponseApi([FromBody] UserInputRequest userInput)
        {
            var chatCompletionRequest = new UserInputRequestRequestPayload
            {
                Model = Commons.GetChatGptModel(userInput.ChatGptModel),
                Input = Commons.GetInputPayload(userInput.UserInput, userInput.SystemInput),
                PreviousResponseId = string.IsNullOrEmpty(userInput.PreviousResponseId) ? null : userInput.PreviousResponseId // null on first request
            };

            var json = JsonSerializer.Serialize(chatCompletionRequest);
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", appSetting.Value.ChatGtpApiKey);

            var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await httpClient.PostAsync(Commons.OpenAiResponsesApi, content);
            var result = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(result);
            var root = doc.RootElement;

            var inputTokens = root.GetProperty("usage").GetProperty("input_tokens");
            var outTokens = root.GetProperty("usage").GetProperty("output_tokens");
            var text = root.GetProperty("output")[0].GetProperty("content")[0].GetProperty("text").GetString() ?? "";
            var previousResponseId = root.GetProperty("id").GetString();

            return new UserInputResponse
            {
                Text = text,
                UsageToken = $"input_tokens: {inputTokens} , output_tokens: {outTokens}",
                PreviousResponseId = previousResponseId,
            };

        }

        [HttpGet("chat-gpt-models")]
        public IList<ChatGptModels> GetChatGptModels()
        {
            return new ChatGptModels().Get();
        }



    }
}
