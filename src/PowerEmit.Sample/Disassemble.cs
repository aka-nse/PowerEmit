using System.Reflection;
using PowerEmit.Disassemblers;

internal class Disassemble : ISampleCase
{
    public void Run()
    {
        var methodInfo = typeof(Disassemble)
            .GetMethod(
                nameof(SampleMethod),
                BindingFlags.Public | BindingFlags.Static)!;

        var disassembled = ILDisassembler.Instance.Disassemble(methodInfo);
        Console.Write(disassembled);
    }

    public static int SampleMethod(int x, int y, int z)
    {
        if(z == 0)
        {
            return x * y;
        }
        else
        {
            return x * y * Math.Sign(z);
        }
    }
}