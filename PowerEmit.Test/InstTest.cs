using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace PowerEmit
{
    public partial class InstTest
    {
        public ITestOutputHelper Output { get; }

        public InstTest(ITestOutputHelper output)
        {
            Output = output;
        }

        private void EmitCore(TestCase testCase)
        {
            var expectedBuilder = new Builder(testCase.ReturnType, testCase.ParameterTypes);
            testCase.Expected(expectedBuilder.ILGenerator);
            var expected = expectedBuilder.GetBuiltILBytes();
            
            var actualBuilder = new Builder(testCase.ReturnType, testCase.ParameterTypes);
            testCase.Actual(actualBuilder.ILGenerator);
            var actual = actualBuilder.GetBuiltILBytes();

            Output.WriteLine("exp: " + string.Join(" ", expected.Select(x => x.ToString("X02"))));
            Output.WriteLine("act: " + string.Join(" ", actual  .Select(x => x.ToString("X02"))));
            Assert.Equal(expected, actual);
        }
    }
}
