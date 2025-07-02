interface UserInputRequest {
  userInput: string;
  systemInput: string;
  chatGptModel: string; 
  previousResponseId: string | null;
}

interface UserInputResponse {
  text: string;
   usageToken: string;
  previousResponseId: string | null;
}

export type { UserInputRequest, UserInputResponse };
