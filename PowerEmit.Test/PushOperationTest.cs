// #define SERIALIZATION_TESTCASES_ENABLED
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace PowerEmit
{
    public partial class PushOperationTest
    {
        public class TestCase
#if SERIALIZATION_TESTCASES_ENABLED
            : IXunitSerializable
#endif
        {
            public string TestName { get; set; }
            public Action<ILGenerator> Expected { get; set; }
            public Action<MethodDescription> Actual { get; set; }
            public Type? ReturnType { get; set; }
            public Type[]? ParameterTypes { get; set; }

            public TestCase(string testname, Action<ILGenerator> expected, Action<MethodDescription> actual, Type? returnType, Type[]? parameterTypes)
            {
                TestName = testname;
                Expected = expected;
                Actual = actual;
                ReturnType = returnType;
                ParameterTypes = parameterTypes;
            }

            public override string ToString() => TestName;

            public void Deserialize(IXunitSerializationInfo info)
            {
                TestName       = info.GetValue<string                   >(nameof(TestName)      );
                Expected       = info.GetValue<Action<ILGenerator>      >(nameof(Expected)      );
                Actual         = info.GetValue<Action<MethodDescription>>(nameof(Actual)        );
                ReturnType     = info.GetValue<Type?                    >(nameof(ReturnType)    );
                ParameterTypes = info.GetValue<Type[]?                  >(nameof(ParameterTypes));
            }

            public void Serialize(IXunitSerializationInfo info)
            {
                info.AddValue(nameof(TestName)      , TestName      );
                info.AddValue(nameof(Expected)      , Expected      );
                info.AddValue(nameof(Actual)        , Actual        );
                info.AddValue(nameof(ReturnType)    , ReturnType    );
                info.AddValue(nameof(ParameterTypes), ParameterTypes);
            }
        }

        private static object[] CreateArgs(string testname, Action<ILGenerator> expected, Action<MethodDescription> actual, Type? returnType = null, Type[]? parameterTypes = null)
            => new object[] { new TestCase(testname, expected, actual, returnType, parameterTypes) };

        private static object[] CreateArgs(OpCode opcode, Action<ILGenerator> expected, Action<MethodDescription> actual)
            => CreateArgs(opcode.Name ?? "unspecified", expected, actual);


        private ITestOutputHelper Output { get; }


        public PushOperationTest(ITestOutputHelper output)
            => Output = output;


        private void PushTestCore(TestCase testCase)
        {
            var testname = testCase.TestName;
            var expected = testCase.Expected;
            var actual = testCase.Actual;
            var returnType = testCase.ReturnType ?? typeof(void);
            var parameterTypes = testCase.ParameterTypes ?? Array.Empty<Type>();
            Output.WriteLine(testname);

            var builder1 = new Builder(returnType, parameterTypes);
            var gen1 = builder1.Method.GetILGenerator();
            expected(gen1);
            var expectedByteArray = builder1.GetILBytes();

            var builder2 = new Builder(returnType, parameterTypes);
            var desc = new MethodDescription(returnType);
            actual(desc);
            desc.BuildMethod(builder2.Method);
            var actualByteArray = builder2.GetILBytes();

            Assert.Equal(expectedByteArray, actualByteArray);
            Output.WriteLine("expected: " + string.Join(" ", expectedByteArray.Select(x => $"{x:X02}")));
            Output.WriteLine("actual  : " + string.Join(" ", actualByteArray  .Select(x => $"{x:X02}")));
        }

    }
}
