// Install the .NET library via NuGet: dotnet add package Azure.AI.OpenAI --prerelease
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.AI.OpenAI;
using Azure.Identity;
using OpenAI.Chat;
using static System.Environment;

namespace Connect.Generate
{
    public class GenerateText
    {
        private AzureOpenAIClient _azureClient { get; set; }
        private ChatClient _chatClient { get; set; }
        public GenerateText(AzureOpenAIClient azureClient , ChatClient chatClient) {
            _azureClient = azureClient;
            _chatClient = chatClient;
        }

        public void Generate()
        {
            // Create a list of chat messages
            var messages = new List<ChatMessage>
          {
              new SystemChatMessage("You are an AI assistant that helps people find information."),

          };

            // Create chat completion options
            var options = new ChatCompletionOptions
            {
                Temperature = (float)0.7,
                MaxOutputTokenCount = 800,
                FrequencyPenalty = 0,
                PresencePenalty = 0,
            };

            try
            {
                // Create the chat completion request
                ChatCompletion completion =  _chatClient.CompleteChatAsync(messages, options).Result;

                // Print the response
                if (completion.Content != null && completion.Content.Count > 0)
                {
                    Console.WriteLine(completion.Content[0].Text.ToString());
                }
                else
                {
                    Console.WriteLine("No response received.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
