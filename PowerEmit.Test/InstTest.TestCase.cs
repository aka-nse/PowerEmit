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
    partial class InstTest
    {
        public class TestCase
#if SERIALIZATION_TESTCASES_ENABLED
            : IXunitSerializable
#endif
        {
            public string TestName { get; set; }
            public Action<ILGenerator> Expected { get; set; }
            public Action<ILGenerator> Actual { get; set; }
            public Type? ReturnType { get; set; }
            public Type[]? ParameterTypes { get; set; }

            public TestCase()
            {
                TestName = "";
                Expected = _ => { };
                Actual = _ => { };
            }

            public TestCase(
                string testname,
                Action<ILGenerator> expected,
                Action<ILGenerator> actual,
                Type? returnType,
                Type[]? parameterTypes)
            {
                TestName       = testname;
                Expected       = expected;
                Actual         = actual;
                ReturnType     = returnType;
                ParameterTypes = parameterTypes;
            }

            public override string ToString() => TestName;

            public void Deserialize(IXunitSerializationInfo info)
            {
                TestName       = info.GetValue<string             >(nameof(TestName)      );
                Expected       = info.GetValue<Action<ILGenerator>>(nameof(Expected)      );
                Actual         = info.GetValue<Action<ILGenerator>>(nameof(Actual)        );
                ReturnType     = info.GetValue<Type?              >(nameof(ReturnType)    );
                ParameterTypes = info.GetValue<Type[]?            >(nameof(ParameterTypes));
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


        public static object[] CreateTestCase(
            string name,
            Action<ILGenerator> expected,
            Action<ILGenerator> actual,
            Type? returnType = null,
            Type[]? parameterTypes = null)
            => new object[] { new TestCase(name, expected, actual, returnType, parameterTypes) };
    }
}
