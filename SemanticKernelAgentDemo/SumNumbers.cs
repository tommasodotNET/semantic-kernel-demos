using System;
using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace SemanticKernelAgentDemo;

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
