using System.Reflection;
using PowerEmit.Disassemblers;

internal class Deoptimize : ISampleCase
{
    public void Run()
    {
        var methodInfo = typeof(Deoptimize)
            .GetMethod(
                nameof(SampleMethod),
                BindingFlags.Public | BindingFlags.Static)!;

        var disassembled = ILDisassembler.Instance.Disassemble(methodInfo);
        var deoptimized = ILDeoptimizer.Instance.Deoptimize(disassembled);
        Console.Write(deoptimized);
    }

    public static int SampleMethod(int x, int y, int z)
    {
        if(z < 0)
        {
            return x * y;
        }
        for(var i = 0; i < z; ++i)
        {
            x += y;
        }
        return Math.Abs(x);
    }
}