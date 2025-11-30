using System.Reflection.Emit;
using Xunit;

namespace PowerEmit.Disassemblers;

public partial class ILDisassemblerTest
{
    [Theory]
    [MemberData(nameof(GetTestCases_Call))]
    public void Disassemble_Call(TestCase testCase)
   => DisassembleCore(testCase);


    public static TheoryData<TestCase> GetTestCases_Call() => [
            CreateTestCase(
                "call (method)",
                gen => gen.Emit(OpCodes.Call, MockType.MethodInfo)),
            CreateTestCase(
                "call (ctor)",
                gen => gen.Emit(OpCodes.Call, MockType.ConstructorInfo)),
            CreateTestCase(
                "call (varargs method)",
                gen => gen.EmitCall(OpCodes.Call, MockType.MethodInfo, [typeof(int), typeof(string)])),
            CreateTestCase(
                "callvirt (method)",
                gen => gen.Emit(OpCodes.Callvirt, MockType.MethodInfo)),
            CreateTestCase(
                "callvirt (varargs method)",
                gen => gen.EmitCall(OpCodes.Callvirt, MockType.MethodInfo, [typeof(int), typeof(string)])),
            CreateTestCase(
                "newobj",
                gen => gen.Emit(OpCodes.Newobj, MockType.ConstructorInfo))
        ];
}