using Microsoft.SemanticKernel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SemanticKernelDemos.Shared;

namespace SemanticKernelDemos.Shared;

public static class KernelProvider
{
    public static AzureOpenAIOptions ReadOpenAIConfig()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
            .Build();

        var services = new ServiceCollection();
        services.Configure<AzureOpenAIOptions>(options => configuration.GetSection("AzureOpenAI").Bind(options));
        var serviceProvider = services.BuildServiceProvider();
        return serviceProvider.GetRequiredService<IOptions<AzureOpenAIOptions>>().Value;
    }

    public static Kernel GetKernel()
    {
        var azureOpenAIOptions = ReadOpenAIConfig();
        IKernelBuilder kernelBuilder = Kernel.CreateBuilder();
        kernelBuilder.AddAzureOpenAIChatCompletion(
            deploymentName: azureOpenAIOptions.DeploymentName,
            apiKey: azureOpenAIOptions.ApiKey,
            endpoint: azureOpenAIOptions.Endpoint
        );
        return kernelBuilder.Build();
    }
}