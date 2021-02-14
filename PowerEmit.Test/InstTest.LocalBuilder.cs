using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Xunit;

namespace PowerEmit
{
    public partial class InstTest
    {
        [Theory]
        [MemberData(nameof(GetTestCases_LocalBuilder))]
        public void Emit_LocalBuilder(TestCase testCase)
            => EmitCore(testCase);


        public static IEnumerable<object[]> GetTestCases_LocalBuilder()
        {
            yield return CreateTestCase(
                "ldloc.s",
                gen => {
                    var loc = gen.DeclareLocal(typeof(MockType));
                    gen.Emit(OpCodes.Ldloc_S, loc);
                },
                gen => {
                    var loc = gen.DeclareLocal(typeof(MockType));
                    gen.Emit(Inst.Ldloc_S(loc));
                });

            yield return CreateTestCase(
                "ldloca.s",
                gen => {
                    var loc = gen.DeclareLocal(typeof(MockType));
                    gen.Emit(OpCodes.Ldloca_S, loc);
                },
                gen => {
                    var loc = gen.DeclareLocal(typeof(MockType));
                    gen.Emit(Inst.Ldloca_S(loc));
                });

            yield return CreateTestCase(
                "ldloc",
                gen => {
                    var loc = gen.DeclareLocal(typeof(MockType));
                    gen.Emit(OpCodes.Ldloc, loc);
                },
                gen => {
                    var loc = gen.DeclareLocal(typeof(MockType));
                    gen.Emit(Inst.Ldloc(loc));
                });

            yield return CreateTestCase(
                "ldloca",
                gen => {
                    var loc = gen.DeclareLocal(typeof(MockType));
                    gen.Emit(OpCodes.Ldloca, loc);
                },
                gen => {
                    var loc = gen.DeclareLocal(typeof(MockType));
                    gen.Emit(Inst.Ldloca(loc));
                });

            yield return CreateTestCase(
                "stloc.s",
                gen => {
                    var loc = gen.DeclareLocal(typeof(MockType));
                    gen.Emit(OpCodes.Stloc_S, loc);
                },
                gen => {
                    var loc = gen.DeclareLocal(typeof(MockType));
                    gen.Emit(Inst.Stloc_S(loc));
                });

            yield return CreateTestCase(
                "stloc",
                gen => {
                    var loc = gen.DeclareLocal(typeof(MockType));
                    gen.Emit(OpCodes.Stloc, loc);
                },
                gen => {
                    var loc = gen.DeclareLocal(typeof(MockType));
                    gen.Emit(Inst.Stloc(loc));
                });

            yield break;
        }


    }
}
