using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace PowerEmit.Disassemblers;

public partial class ILDisassemblerTest(ITestOutputHelper output)
{
    public ITestOutputHelper Output { get; } = output;

    private void DisassembleCore(TestCase testCase)
    {
        var expected = testCase.Method.GetMethodBody()!.GetILAsByteArray()!;

        var disassembled = ILDisassembler.Instance.Disassemble(testCase.Method);

        var builder = new Builder(
            testCase.Method.ReturnType,
            [.. testCase.Method.GetParameters().Select(p => p.ParameterType)]);
        foreach(var action in disassembled.ILActions)
        {
            builder.ILGenerator.Emit(action);
        }

        byte[] actual;
        try
        {
            actual = builder.GetBuiltILBytes()!;
        }
        catch
        {
            Output.WriteLine("Failed to get built IL bytes.");
            foreach(var action in disassembled.ILActions)
            {
                Output.WriteLine($"  {action.ToString()}");
            }
            throw;
        }

        try
        {
            Assert.Equal(expected, actual);
        }
        catch
        {
            var exp = "exp: " + string.Join(" ", expected.Select(static x => $"{x:X02}"));
            var act = "act: " + string.Join(" ", actual.Select(static x => $"{x:X02}"));
            Output.WriteLine(exp);
            Output.WriteLine(act);
            throw;
        }
    }
}