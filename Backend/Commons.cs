using ChatGpt.Models;
using ChatGpt.Models.WebModels;
using OpenAI.Chat;

namespace ChatGpt
{
    public static class Commons
    {
        public const string OpenAiResponsesApi="https://api.openai.com/v1/responses";
        public static string GetChatGptModel(string? chatGptModel = null)
        {
            if (string.IsNullOrWhiteSpace(chatGptModel))
            {
                chatGptModel = new ChatGptModels()
                    .Get()
                    .FirstOrDefault(m => m.IsDefault)?.ModelName;
            }
            return chatGptModel!;
        }

        public static IList<ChatMessage> GetChatMessages(string userInputMessage, string? systemInputMessage = null)
        {
            var inputMessages = new List<ChatMessage>();
            if (!string.IsNullOrWhiteSpace(systemInputMessage))
            {
                inputMessages.Add(ChatMessage.CreateSystemMessage(systemInputMessage));
            }
            inputMessages.Add(ChatMessage.CreateUserMessage(userInputMessage));
            return inputMessages;
        }
        public static IList<InputPayload> GetInputPayload(string userInputMessage, string? systemInputMessage = null)
        {
            var inputMessages = new List<InputPayload>();
            if (!string.IsNullOrWhiteSpace(systemInputMessage))
            {
                inputMessages.Add(InputPayload.CreateSystemMessage(systemInputMessage));
            }
            inputMessages.Add(InputPayload.CreateUserMessage(userInputMessage));
            return inputMessages;
        }
    }
}
