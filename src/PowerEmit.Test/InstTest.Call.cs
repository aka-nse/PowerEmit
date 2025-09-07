using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Xunit;


namespace PowerEmit;

public partial class InstTest
{
    [Theory]
    [MemberData(nameof(GetTestCases_Call))]
    public void Emit_Call(TestCase testCase)
        => EmitCore(testCase);


    public static TheoryData<TestCase> GetTestCases_Call() =>
        [
            CreateTestCase(
                "call (method)",
                Inst.Call(MockType.MethodInfo),
                gen => gen.Emit(OpCodes.Call, MockType.MethodInfo)),
            CreateTestCase(
                "call (ctor)",
                Inst.Call(MockType.ConstructorInfo),
                gen => gen.Emit(OpCodes.Call, MockType.ConstructorInfo)),
            CreateTestCase(
                "call (varargs method)",
                Inst.Call(MockType.MethodInfo, [typeof(int), typeof(string)]),
                gen => gen.EmitCall(OpCodes.Call, MockType.MethodInfo, [typeof(int), typeof(string)])),
            CreateTestCase(
                "callvirt (method)",
                Inst.Callvirt(MockType.MethodInfo),
                gen => gen.Emit(OpCodes.Callvirt, MockType.MethodInfo)),
            CreateTestCase(
                "callvirt (varargs method)",
                Inst.Callvirt(MockType.MethodInfo, [typeof(int), typeof(string)]),
                gen => gen.EmitCall(OpCodes.Callvirt, MockType.MethodInfo, [typeof(int), typeof(string)])),
            CreateTestCase(
                "newobj",
                Inst.Newobj(MockType.ConstructorInfo),
                gen => gen.Emit(OpCodes.Newobj, MockType.ConstructorInfo)),
        ];
}