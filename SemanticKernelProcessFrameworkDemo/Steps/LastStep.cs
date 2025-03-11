using System;
using Microsoft.SemanticKernel;

namespace SemanticKernelProcessFrameworkDemo.Steps;

public class LastStep : KernelProcessStep
{
    [KernelFunction]
    public async ValueTask ExecuteAsync(KernelProcessStepContext context)
    {
        Console.WriteLine("Step 4 - This is the Final Step...\n");
    }
}