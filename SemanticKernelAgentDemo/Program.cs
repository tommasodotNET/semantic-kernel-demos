using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using SemanticKernelAgentDemo;
using SemanticKernelDemos.Shared;

var textToSummarize = await File.ReadAllTextAsync("text.txt");

var kernel = KernelProvider.GetKernel();

// Create the agent
ChatCompletionAgent summaryAgent =
    new()
    {
        Name = "SummarizationAgent",
        Instructions = "Summarize user input",
        Kernel = kernel
    };

// Create a ChatHistory object to maintain the conversation state.
ChatHistory chat = [];

// Add a user message to the conversation
chat.Add(new ChatMessageContent(AuthorRole.User, textToSummarize));

// Generate the agent response(s)
await foreach (ChatMessageContent response in summaryAgent.InvokeAsync(chat))
{
    chat.AddAssistantMessage(response.ToString());
    Console.WriteLine(response);
}

// ----------------------------------------------

var _settings = new OpenAIPromptExecutionSettings()
{
    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions,
    Temperature = 0.1,
    MaxTokens = 500,
};
ChatCompletionAgent sumAgent = 
    new()
    {
        Name = "SumAgent",
        Instructions = "Sum two numbers using your available plugins",
        Kernel = kernel,
        Arguments = new(_settings)
    };
sumAgent.Kernel.Plugins.AddFromType<SumNumbers>();

chat = [];

chat.Add(new ChatMessageContent(AuthorRole.User, "Sum 5 and 7"));

await foreach (ChatMessageContent response in sumAgent.InvokeAsync(chat))
{
    Console.WriteLine(response);
}