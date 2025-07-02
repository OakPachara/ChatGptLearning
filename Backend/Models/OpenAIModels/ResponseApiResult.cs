using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ChatGpt.Models.OpenAIModels
{
    public class ResponseApiResult
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("object")]
        public string? Object { get; set; }

        [JsonPropertyName("created_at")]
        public long? CreatedAt { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("background")]
        public bool? Background { get; set; }

        [JsonPropertyName("error")]
        public object? Error { get; set; }

        [JsonPropertyName("incomplete_details")]
        public object? IncompleteDetails { get; set; }

        [JsonPropertyName("instructions")]
        public object? Instructions { get; set; }

        [JsonPropertyName("max_output_tokens")]
        public int? MaxOutputTokens { get; set; }

        [JsonPropertyName("model")]
        public string? Model { get; set; }

        [JsonPropertyName("output")]
        public List<OutputItem>? Output { get; set; }

        [JsonPropertyName("parallel_tool_calls")]
        public bool? ParallelToolCalls { get; set; }

        [JsonPropertyName("previous_response_id")]
        public string? PreviousResponseId { get; set; }

        [JsonPropertyName("reasoning")]
        public Reasoning? Reasoning { get; set; }

        [JsonPropertyName("service_tier")]
        public string? ServiceTier { get; set; }

        [JsonPropertyName("store")]
        public bool? Store { get; set; }

        [JsonPropertyName("temperature")]
        public double? Temperature { get; set; }

        [JsonPropertyName("text")]
        public TextFormatWrapper? Text { get; set; }

        [JsonPropertyName("tool_choice")]
        public string? ToolChoice { get; set; }

        [JsonPropertyName("tools")]
        public List<object>? Tools { get; set; }

        [JsonPropertyName("top_p")]
        public double? TopP { get; set; }

        [JsonPropertyName("truncation")]
        public string? Truncation { get; set; }

        [JsonPropertyName("usage")]
        public Usage? Usage { get; set; }

        [JsonPropertyName("user")]
        public object? User { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, object>? Metadata { get; set; }
    }

    public class OutputItem
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("content")]
        public List<ContentItem>? Content { get; set; }

        [JsonPropertyName("role")]
        public string? Role { get; set; }
    }

    public class ContentItem
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("annotations")]
        public List<object>? Annotations { get; set; }

        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }

    public class Reasoning
    {
        [JsonPropertyName("effort")]
        public object? Effort { get; set; }

        [JsonPropertyName("summary")]
        public object? Summary { get; set; }
    }

    public class TextFormatWrapper
    {
        [JsonPropertyName("format")]
        public TextFormat? Format { get; set; }
    }

    public class TextFormat
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }

    public class Usage
    {
        [JsonPropertyName("input_tokens")]
        public int? InputTokens { get; set; }

        [JsonPropertyName("input_tokens_details")]
        public InputTokensDetails? InputTokensDetails { get; set; }

        [JsonPropertyName("output_tokens")]
        public int? OutputTokens { get; set; }

        [JsonPropertyName("output_tokens_details")]
        public OutputTokensDetails? OutputTokensDetails { get; set; }

        [JsonPropertyName("total_tokens")]
        public int? TotalTokens { get; set; }
    }

    public class InputTokensDetails
    {
        [JsonPropertyName("cached_tokens")]
        public int? CachedTokens { get; set; }
    }

    public class OutputTokensDetails
    {
        [JsonPropertyName("reasoning_tokens")]
        public int? ReasoningTokens { get; set; }
    }
}