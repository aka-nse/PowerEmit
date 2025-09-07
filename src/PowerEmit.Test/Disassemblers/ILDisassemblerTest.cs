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
            builder.ILGenerator.Emit(action);
        var actual = builder.GetBuiltILBytes()!;

        Output.WriteLine("exp: " + string.Join(" ", expected.Select(x => x.ToString("X02"))));
        Output.WriteLine("act: " + string.Join(" ", actual.Select(x => x.ToString("X02"))));
        Assert.Equal(expected, actual);
    }
}