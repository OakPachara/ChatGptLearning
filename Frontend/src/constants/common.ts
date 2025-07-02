const API_BASE_URL = import.meta.env.VITE_API_BASE_URL;

export const ApiConstants = {
  BASE_URL: API_BASE_URL,
  CHAT_COMPLETIONS: API_BASE_URL + "/chat-gpt/complete-chat",
  RESPONSES_API: API_BASE_URL + "/chat-gpt/responses-api",
  CHAT_GPT_MODEL: API_BASE_URL + "/chat-gpt/chat-gpt-models",
} as const;
