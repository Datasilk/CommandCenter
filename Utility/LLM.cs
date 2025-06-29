using OpenAI.Chat;


namespace CommandCenter.Utility
{
    public class LLM
    {
        public static string PrivateKey = "";

        public static string Prompt(string system, string assistant, string user)
        {
            if (string.IsNullOrEmpty(PrivateKey))
            {
                throw new Exception("LLM private key is missing");
            }
            ChatClient client = new ChatClient("qwen-turbo-latest", new System.ClientModel.ApiKeyCredential(PrivateKey), new OpenAI.OpenAIClientOptions()
            {
                Endpoint = new Uri("https://dashscope-intl.aliyuncs.com/compatible-mode/v1")
            });

            List<ChatMessage> prompt = new List<ChatMessage>()
            {
                new SystemChatMessage(system),
                new AssistantChatMessage(assistant),
                new UserChatMessage(user)
            };
            ChatCompletion completion = client.CompleteChat(prompt);
            return completion.Content[0].Text;
        }
    }
}
