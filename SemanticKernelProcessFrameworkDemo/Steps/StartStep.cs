using System;
using Microsoft.SemanticKernel;

namespace SemanticKernelProcessFrameworkDemo.Steps;

public class StartStep : KernelProcessStep
{
    [KernelFunction]
    public async ValueTask ExecuteAsync(KernelProcessStepContext context)
    {
        Console.WriteLine("Step 1 - Start\n");
    }
}