using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Xunit;

namespace PowerEmit.Disassemblers
{
    public partial class ILDisassemblerTest
    {
        [Theory]
        [MemberData(nameof(GetTestCases_Call))]
        public void Disassemble_Call(TestCase testCase)
       => DisassembleCore(testCase);


        public static IEnumerable<object[]> GetTestCases_Call()
        {
            yield return CreateTestCase(
                "call (method)",
                gen => gen.Emit(OpCodes.Call, MockType.MethodInfo));
            yield return CreateTestCase(
                "call (ctor)",
                gen => gen.Emit(OpCodes.Call, MockType.ConstructorInfo));
            yield return CreateTestCase(
                "call (varargs method)",
                gen => gen.EmitCall(OpCodes.Call, MockType.MethodInfo, new[] { typeof(int), typeof(string) }));

            yield return CreateTestCase(
                "callvirt (method)",
                gen => gen.Emit(OpCodes.Callvirt, MockType.MethodInfo));
            yield return CreateTestCase(
                "callvirt (varargs method)",
                gen => gen.EmitCall(OpCodes.Callvirt, MockType.MethodInfo, new[] { typeof(int), typeof(string) }));

            yield return CreateTestCase(
                "newobj",
                gen => gen.Emit(OpCodes.Newobj, MockType.ConstructorInfo));
            yield break;
        }
    }
}