using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace PowerEmit;

public partial class InstTest(ITestOutputHelper output)
{
    public ITestOutputHelper Output { get; } = output;

    private void EmitCore(TestCase testCase)
    {
        var expectedBuilder = new Builder(testCase.ReturnType, testCase.ParameterTypes);
        testCase.Expected(expectedBuilder.ILGenerator);
        var expected = expectedBuilder.GetBuiltILBytes()!;

        var actualBuilder = new Builder(testCase.ReturnType, testCase.ParameterTypes);
        testCase.Actual(actualBuilder.ILGenerator);
        var actual = actualBuilder.GetBuiltILBytes()!;

        Output.WriteLine("exp: " + string.Join(" ", expected.Select(x => x.ToString("X02"))));
        Output.WriteLine("act: " + string.Join(" ", actual.Select(x => x.ToString("X02"))));
        Assert.Equal(expected, actual);
    }
}