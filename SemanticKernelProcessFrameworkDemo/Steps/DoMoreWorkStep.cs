using System;
using Microsoft.SemanticKernel;

namespace SemanticKernelProcessFrameworkDemo.Steps;

public class DoMoreWorkStep : KernelProcessStep
{
    [KernelFunction]
    public async ValueTask ExecuteAsync(KernelProcessStepContext context)
    {
        Console.WriteLine("Step 3 - Doing Yet More Work...\n");
    }
}
