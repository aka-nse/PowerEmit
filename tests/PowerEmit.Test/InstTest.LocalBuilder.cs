using System.Collections.Generic;
using System.Reflection.Emit;
using Xunit;

namespace PowerEmit;

public partial class InstTest
{
    [Theory]
    [MemberData(nameof(GetTestCases_LocalBuilder))]
    public void Emit_LocalBuilder(TestCase testCase)
        => EmitCore(testCase);


    public static TheoryData<TestCase> GetTestCases_LocalBuilder() =>
    [
        CreateTestCase(
            "ldloc.s",
            gen =>
            {
                var loc = gen.DeclareLocal(typeof(MockType));
                gen.Emit(OpCodes.Ldloc_S, loc);
            },
            gen =>
            {
                var loc = gen.DeclareLocal(typeof(MockType));
                gen.Emit(Inst.Ldloc_S(loc));
            }),
        CreateTestCase(
            "ldloca.s",
            gen =>
            {
                var loc = gen.DeclareLocal(typeof(MockType));
                gen.Emit(OpCodes.Ldloca_S, loc);
            },
            gen =>
            {
                var loc = gen.DeclareLocal(typeof(MockType));
                gen.Emit(Inst.Ldloca_S(loc));
            }),
        CreateTestCase(
            "ldloc",
            gen =>
            {
                var loc = gen.DeclareLocal(typeof(MockType));
                gen.Emit(OpCodes.Ldloc, loc);
            },
            gen =>
            {
                var loc = gen.DeclareLocal(typeof(MockType));
                gen.Emit(Inst.Ldloc(loc));
            }),
        CreateTestCase(
            "ldloca",
            gen =>
            {
                var loc = gen.DeclareLocal(typeof(MockType));
                gen.Emit(OpCodes.Ldloca, loc);
            },
            gen =>
            {
                var loc = gen.DeclareLocal(typeof(MockType));
                gen.Emit(Inst.Ldloca(loc));
            }),
        CreateTestCase(
            "stloc.s",
            gen =>
            {
                var loc = gen.DeclareLocal(typeof(MockType));
                gen.Emit(OpCodes.Stloc_S, loc);
            },
            gen =>
            {
                var loc = gen.DeclareLocal(typeof(MockType));
                gen.Emit(Inst.Stloc_S(loc));
            }),
        CreateTestCase(
            "stloc",
            gen =>
            {
                var loc = gen.DeclareLocal(typeof(MockType));
                gen.Emit(OpCodes.Stloc, loc);
            },
            gen =>
            {
                var loc = gen.DeclareLocal(typeof(MockType));
                gen.Emit(Inst.Stloc(loc));
            }),
    ];


}