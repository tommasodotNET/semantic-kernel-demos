# Semantic Kernel Demos

This repository contains various samples demonstrating the use of Semantic Kernel, ChatCompletionAgents, Group Chat, and Assistant Agents.

# Introduction
Semantic Kernel is a powerful tool for building intelligent applications. This repository provides several demos to help you get started with Semantic Kernel, including examples of ChatCompletionAgents, Group Chat, and Assistant Agents.

# Prerequisites
- .NET 9.0
- Microsoft.SemanticKernel
- Azure.AI.OpenAI

- An IDE such as Visual Studio or Visual Studio Code

## Getting Started

1. Clone the repository:
    ```sh
    git clone https://github.com/your-repo/semantic-kernel-demos.git
    ```

2. Navigate to the project directory:
    ```sh
    cd semantic-kernel-demos
    ```

3. Build the projects:
    ```sh
    dotnet build
    ```

4. Run the desired demo project:
    ```sh
    dotnet run --project SemanticKernelGroupChatDemo
    ```

# Samples

The Kernel is always configured using helper methods provided by the [SemanticKernelDemos.Shared](./SemanticKernelDemos.Shared) project.

# Semantic Kernel Chat Completion
This [demo](./SemanticKernelDemo/Program.cs) showcases the use of Semantic Kernel to complete a chat conversation. There is no agent involved in this demo.

# Semantic Kernel Agent Demo
This [demo](./SemanticKernelAgentDemo/Program.cs) showcases the use of a Semantic Kernel agent to perform tasks such as summarizing text and summing numbers.

# Semantic Kernel Assistant Agent Demo
This [demo](./SemanticKernelAssistantAgentDemo/Program.cs) demonstrates how to create an assistant agent using Semantic Kernel and OpenAI. The assistant can summarize text and perform simple arithmetic operations.

# Semantic Kernel Group Chat Demo
This [demo](./SemanticKernelGroupChatDemo/Program.cs) showcases a group chat scenario using different types of agents:

- **CodeValidator**: Evaluates the quality of the code.
- **JuniorDeveloper**: Writes intentionally bad code.
- **ExpertDeveloper**: Writes high-quality code.
- **AgentGroupChat**: Manages the conversation flow between different agents.
- **KernelFunctionTerminationStrategy**: Determines when the conversation should end.
- **KernelFunctionSelectionStrategy**: Selects the next agent to respond based on the conversation history.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License.
