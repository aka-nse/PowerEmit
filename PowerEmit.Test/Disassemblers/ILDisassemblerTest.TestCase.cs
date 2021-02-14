// #define SERIALIZATION_TESTCASES_ENABLED
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace PowerEmit.Disassemblers
{
    partial class ILDisassemblerTest
    {
        public class TestCase
#if SERIALIZATION_TESTCASES_ENABLED
            : IXunitSerializable
#endif
        {
            public string TestName { get; set; }
            public MethodInfo Method { get; set; }

            public TestCase()
            {
                TestName = "";
                Method = null!;
            }

            public TestCase(string testname, MethodInfo method)
            {
                TestName = testname;
                Method = method;
            }

            public override string ToString() => TestName;

            public void Deserialize(IXunitSerializationInfo info)
            {
                TestName = info.GetValue<string>(nameof(TestName));
                Method = info.GetValue<MethodInfo>(nameof(Method));
            }

            public void Serialize(IXunitSerializationInfo info)
            {
                info.AddValue(nameof(TestName), TestName);
                info.AddValue(nameof(Method), Method);
            }
        }


        public static object[] CreateTestCase(
            string name,
            MethodInfo method)
            => new object[] { new TestCase(name, method) };


        public static object[] CreateTestCase(
            string name,
            Action<ILGenerator> expected)
        {
            var builder = new Builder(typeof(void), null);
            expected(builder.ILGenerator);
            return CreateTestCase(name, builder.GetBuiltMethodInfo());
        }
    }
}
