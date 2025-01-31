using Microsoft.SemanticKernel.ChatCompletion;
using SemanticKernelDemos.Shared;

var kernel = KernelProvider.GetKernel();

ChatHistory history = [];
history.AddUserMessage("Hello, how are you?");

var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

var response = await chatCompletionService.GetChatMessageContentAsync(
    history
);

Console.WriteLine(response.ToString());