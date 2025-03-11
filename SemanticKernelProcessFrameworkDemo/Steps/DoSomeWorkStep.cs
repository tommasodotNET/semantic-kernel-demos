using System;
using Microsoft.SemanticKernel;

namespace SemanticKernelProcessFrameworkDemo.Steps;

public class DoSomeWorkStep : KernelProcessStep
{
    [KernelFunction]
    public async ValueTask ExecuteAsync(KernelProcessStepContext context)
    {
        Console.WriteLine("Step 2 - Doing Some Work...\n");
    }
}