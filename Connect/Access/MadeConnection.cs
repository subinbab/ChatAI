using Azure.AI.OpenAI;
using Azure.Identity;
using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect.Access
{
    public class MadeConnection
    {
        public AzureOpenAIClient _azureClient { get; set; }
        public ChatClient _chatClient { get; set; }
        public MadeConnection()
        {
            _azureClient = new(
        new Uri("https://111111111111111111111111.openai.azure.com/"),
        new System.ClientModel.ApiKeyCredential("1111111111111111111111111111111111111111"));
            _chatClient = _azureClient.GetChatClient("11111111111111111111111111");
        }
        public ChatClient ConnectToAzureOpenAI()
        {

            return new MadeConnection()._chatClient;
        }
    }
}
