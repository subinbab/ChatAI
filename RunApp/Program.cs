// See https://aka.ms/new-console-template for more information
using Connect.Access;
using Connect.Generate;

Console.WriteLine("connecting to open ai chat bot .........");

var result = new MadeConnection();
var chat = new GenerateText(result._azureClient,result._chatClient);
chat.Generate();
Console.ReadKey();
