<template>
  <div class="space-y-2 flex flex-col">
    <!-- Model Selection -->
    <div class="flex flex-row items-center justify-between">
      <span class="flex items-center">
        <span class="text-3xl pr-2"></span>
        <select v-model="inputRequest.chatGptModel" class="w-40 not-even:bg-transparent">
          <option v-for="option in modelOptions" :key="option.modelName" :value="option.modelName">
            {{ option.displayText }}
          </option>
        </select>
      </span>
      <span class="flex flex-col items-end">
        <small> {{ usageToken }} </small>
        <small> Previous Response ID {{ inputRequest.previousResponseId }} </small>
      </span>
    </div>

    <div v-if="messages.length" ref="chatContainer" class="marked-message space-y-2">
      <div v-for="(msg, index) in messages" :key="index" class="flex" :class="msg.role === 'user' ? 'user' : 'bot'">
        <div v-html="msg.content"></div>
      </div>
    </div>

    <!-- User Input -->
    <div class="flex flex-row items-start space-x-2">
      <textarea
        rows="4"
        v-model="inputRequest.userInput"
        placeholder="User Input Message"
        type="text"
        class="w-full py-3 px-3 border-0 rounded-2xl bg-gray-200"
        style="resize: none"
      />
      <!-- Button -->
      <button @click="fetchResponseAsync" class="bg-cyan-900 p-3 rounded-2xl">
        <!-- <span class="mdi mdi-arrow-up-circle text-3xl"></span> -->
              <span class="p-2">▲</span>
      </button>

    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, nextTick } from "vue";
import axios from "axios";
import MarkdownIt from "markdown-it";
import hljs from "highlight.js";

import { ApiConstants } from "../constants/common";
import type { ModelOption } from "../types/chatGpt/ModelOption";
import type { UserInputRequest, UserInputResponse } from "../types/chatGpt/UserInputRequest";
import "highlight.js/styles/github-dark.css";
import "@jamescoyle/svg-icon";

// const loading = ref<boolean>(false);

const modelOptions = ref<ModelOption[]>([]);
const inputRequest = ref<UserInputRequest>({
  chatGptModel: "",
  userInput: "",
  systemInput: "",
  previousResponseId: "",
});
const messages = ref<{ role: "user" | "bot"; content: string }[]>([]);
const chatContainer = ref<HTMLElement | null>(null);
const usageToken = ref<string>("");
const fetchResponseAsync = async () => {
  if (!inputRequest.value.userInput?.trim()) {
    return;
  }

  // Add user message
  messages.value.push({
    role: "user",
    content: markdownInstance.render(inputRequest.value.userInput),
  });

  // Call Api
  const response = await axios.post<UserInputResponse>(ApiConstants.RESPONSES_API, inputRequest.value);

  // Add bot message
  messages.value.push({
    role: "bot",
    content: markdownInstance.render(response.data.text),
  });

  await nextTick();
  if (!chatContainer.value) {
    return;
  }

  chatContainer.value.scrollTop = chatContainer.value.scrollHeight;
  inputRequest.value.previousResponseId = response.data.previousResponseId;
  inputRequest.value.userInput = "";
  usageToken.value = response.data.usageToken;
};

const markdownInstance = new MarkdownIt({
  linkify: true,
  highlight: (str, lang) => {
    // Generate a unique id for the hidden input
    const inputId = `copy-code-${
      typeof crypto !== "undefined" && typeof crypto.randomUUID === "function"
        ? crypto.randomUUID()
        : Math.random().toString(36).slice(2, 11)
    }`;

    const copyButton = `
      <div class="code-lang">
        <label>${lang || ""}</label>
        <input type="hidden" id="${inputId}" value="${MarkdownIt().utils.escapeHtml(str)}"/>
        <a class="mdi mdi-content-copy"
          style="background:transparent;border:none;cursor:pointer;"
          onclick="(function(){
           var input = document.getElementById('${inputId}');
           if(input) navigator.clipboard.writeText(input.value);
          })()"
        ></a>
      </div>`;

    if (lang && hljs.getLanguage(lang)) {
      return `${copyButton}<pre><code class="hljs">${hljs.highlight(str, { language: lang }).value}</code></pre>`;
    }
    return `${copyButton}<pre><code>${MarkdownIt().utils.escapeHtml(str)}</code></pre>`;
  },
});

onMounted(async () => {
  const response = await axios.get(ApiConstants.CHAT_GPT_MODEL);
  modelOptions.value = response.data;
  const defaultModel = modelOptions.value.find((c) => c.isDefault);
  inputRequest.value.chatGptModel = defaultModel ? defaultModel.modelName : "";
});
</script>

<!-- <span class="ml-4">
        <input
          v-model="responseApiParams.systemInput"
          type="text"
          placeholder="System Message (optional)"
          class="w-80 py-3 px-3 rounded-2xl bg-gray-200"
        />
      </span> -->
