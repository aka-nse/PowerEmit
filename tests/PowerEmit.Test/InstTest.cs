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
        var forcastedByteSize = testCase.TestTargetAction?.ByteSize ?? -1;
        try
        {
            if(forcastedByteSize > 0)
            {
                Assert.Equal(expected.Length, forcastedByteSize);
            }
            Assert.Equal(expected, actual);
        }
        catch
        {
            Output.WriteLine($"byte size: {forcastedByteSize}");
            Output.WriteLine("exp: " + string.Join(" ", expected.Select(x => x.ToString("X02"))));
            Output.WriteLine("act: " + string.Join(" ", actual.Select(x => x.ToString("X02"))));
            throw;
        }
    }
}