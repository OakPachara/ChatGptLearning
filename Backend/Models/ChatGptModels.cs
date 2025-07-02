namespace ChatGpt.Models
{
    // List of ChatGPT models with their details
    //https://platform.openai.com/docs/models
    public class ChatGptModels
    {
        public string ModelName { get; set; } = null!;
        public string DisplayText { get; set; } = null!;
        public decimal PricePerInput1mToken { get; set; }
        public decimal PricePerOutput1mToken { get; set; }
        public bool IsDefault { get; set; } = false;

        public List<ChatGptModels> Get()
        {
            return
            [
                new() {
                    ModelName = "o4-mini",
                    DisplayText = "ChatGPT o4-mini",
                    PricePerInput1mToken = 1.10M,
                    PricePerOutput1mToken = 4.40M,
                },
                new() {
                    ModelName = "gpt-4o",
                    DisplayText = "ChatGPT 4o",
                    PricePerInput1mToken = 2.50M,
                    PricePerOutput1mToken = 10.00M,
                    IsDefault = false,

                },
                new() {
                    ModelName = "gpt-4o-mini",
                    DisplayText = "ChatGPT 4o-mini",
                    PricePerInput1mToken = 0.15M,
                    PricePerOutput1mToken = 0.60M,
                        IsDefault = false,
                },
                new() {
                    ModelName = "gpt-4.1",
                    DisplayText = "ChatGPT 4.1",
                    PricePerInput1mToken = 2.00M,
                    PricePerOutput1mToken = 8.00M
                },
                new() {
                    ModelName = "gpt-4.1-mini",
                    DisplayText = "ChatGPT 4.1-mini",
                    PricePerInput1mToken = 0.40M,
                    PricePerOutput1mToken = 1.60M,
                    IsDefault = true,
                }
            ];
        }
    }

}
