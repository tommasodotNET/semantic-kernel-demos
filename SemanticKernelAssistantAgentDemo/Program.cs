using System.ComponentModel;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents.OpenAI;
using Microsoft.SemanticKernel.ChatCompletion;
using SemanticKernelDemos.Shared;

var textToSummarize = await File.ReadAllTextAsync("text.txt");

var azureOpenAIOptions = KernelProvider.ReadOpenAIConfig();

OpenAIAssistantAgent agent =
    await OpenAIAssistantAgent.CreateAsync(
        OpenAIClientProvider.ForAzureOpenAI(new System.ClientModel.ApiKeyCredential(azureOpenAIOptions.ApiKey), new Uri(azureOpenAIOptions.Endpoint)),
        new OpenAIAssistantDefinition(azureOpenAIOptions.DeploymentName)
        {
            Name = "Assistant",
            Instructions = "Summarize user input. You can also ask me to sum two numbers.",
        },
        new Kernel());
agent.Kernel.Plugins.AddFromType<SumNumbers>();

// Create a thread for the agent conversation.
string threadId = await agent.CreateThreadAsync();

// Add a user message to the conversation
await agent.AddChatMessageAsync(threadId, new ChatMessageContent(AuthorRole.User, "Sum 5 and 7"));

// Generate the agent response(s)
await foreach (ChatMessageContent response in agent.InvokeAsync(threadId))
{
  Console.WriteLine(response);
}

// Delete the thread when it is no longer needed
await agent.DeleteThreadAsync(threadId);

public class SumNumbers
{
    [KernelFunction("Sum")]
    [Description("Sum two numbers")]
    public static int Sum(
        [Description("first number")]int a, 
        [Description("second number")]int b)
    {
        return a + b;
    }
}
