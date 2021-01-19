using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using Xunit;

namespace PowerEmit
{
    public partial class PushOperationTest
    {
        [Theory]
        [MemberData(nameof(TestArgs_Integration))]
        private void PushTest_Integration(TestCase testCase)
            => PushTestCore(testCase);


        public static IEnumerable<object[]> TestArgs_Integration()
        {
            yield return CreateArgs(
                "AddInt32",
                gen => {
                    gen.Emit(OpCodes.Ldarg_0);
                    gen.Emit(OpCodes.Ldarg_1);
                    gen.Emit(OpCodes.Add);
                    gen.Emit(OpCodes.Ret);
                },
                desc => {
                    desc.Stream.Add(OpCodeX.Ldarg_0());
                    desc.Stream.Add(OpCodeX.Ldarg_1());
                    desc.Stream.Add(OpCodeX.Add());
                    desc.Stream.Add(OpCodeX.Ret());
                },
                typeof(int), new Type[] { typeof(int), typeof(int) });
            yield return CreateArgs(
                "Factorial",
                gen => {
                    var IL_0000 = gen.DefineLabel();
                    var IL_0001 = gen.DefineLabel();
                    var IL_0002 = gen.DefineLabel();
                    var IL_0003 = gen.DefineLabel();
                    var IL_0004 = gen.DefineLabel();
                    var IL_0005 = gen.DefineLabel();
                    var IL_0007 = gen.DefineLabel();
                    var IL_0008 = gen.DefineLabel();
                    var IL_0009 = gen.DefineLabel();
                    var IL_000a = gen.DefineLabel();
                    var IL_000b = gen.DefineLabel();
                    var IL_000c = gen.DefineLabel();
                    var IL_000d = gen.DefineLabel();
                    var IL_000e = gen.DefineLabel();
                    var IL_000f = gen.DefineLabel();
                    var IL_0010 = gen.DefineLabel();
                    var IL_0011 = gen.DefineLabel();
                    var IL_0012 = gen.DefineLabel();
                    var IL_0013 = gen.DefineLabel();
                    var IL_0015 = gen.DefineLabel();
                    var IL_0016 = gen.DefineLabel();
                    gen.MarkLabel(IL_0000); gen.Emit(OpCodes.Ldc_I4_1);           // IL_0000: ldc.i4.1
                    gen.MarkLabel(IL_0001); gen.Emit(OpCodes.Conv_I8);            // IL_0001: conv.i8
                    gen.MarkLabel(IL_0002); gen.Emit(OpCodes.Stloc_0);            // IL_0002: stloc.0
                    gen.MarkLabel(IL_0003); gen.Emit(OpCodes.Ldarg_0);            // IL_0003: ldarg.0
                    gen.MarkLabel(IL_0004); gen.Emit(OpCodes.Stloc_1);            // IL_0004: stloc.1
                                                                                  // // sequence point: hidden
                    gen.MarkLabel(IL_0005); gen.Emit(OpCodes.Br_S, IL_0010);      // IL_0005: br.s IL_0010
                                                                                  // // loop start (head: IL_0010)
                        gen.MarkLabel(IL_0007); gen.Emit(OpCodes.Ldloc_0);        //     IL_0007: ldloc.0
                        gen.MarkLabel(IL_0008); gen.Emit(OpCodes.Ldloc_1);        //     IL_0008: ldloc.1
                        gen.MarkLabel(IL_0009); gen.Emit(OpCodes.Mul);            //     IL_0009: mul
                        gen.MarkLabel(IL_000a); gen.Emit(OpCodes.Stloc_0);        //     IL_000a: stloc.0
                        gen.MarkLabel(IL_000b); gen.Emit(OpCodes.Ldloc_1);        //     IL_000b: ldloc.1
                        gen.MarkLabel(IL_000c); gen.Emit(OpCodes.Ldc_I4_1);       //     IL_000c: ldc.i4.1
                        gen.MarkLabel(IL_000d); gen.Emit(OpCodes.Conv_I8);        //     IL_000d: conv.i8
                        gen.MarkLabel(IL_000e); gen.Emit(OpCodes.Sub);            //     IL_000e: sub
                        gen.MarkLabel(IL_000f); gen.Emit(OpCodes.Stloc_1);        //     IL_000f: stloc.1
                                                                                  //
                        gen.MarkLabel(IL_0010); gen.Emit(OpCodes.Ldloc_1);        //     IL_0010: ldloc.1
                        gen.MarkLabel(IL_0011); gen.Emit(OpCodes.Ldc_I4_0);       //     IL_0011: ldc.i4.0
                        gen.MarkLabel(IL_0012); gen.Emit(OpCodes.Conv_I8);        //     IL_0012: conv.i8
                        gen.MarkLabel(IL_0013); gen.Emit(OpCodes.Bgt_S, IL_0007); //     IL_0013: bgt.s IL_0007
                                                                                  // // end loop
                                                                                  //
                    gen.MarkLabel(IL_0015); gen.Emit(OpCodes.Ldloc_0);            // IL_0015: ldloc.0
                    gen.MarkLabel(IL_0016); gen.Emit(OpCodes.Ret);                // IL_0016: ret
                },
                desc => {
                    var retval = desc.AddArgument(typeof(long), "retval");
                    var x = desc.AddArgument(typeof(long), "x");
                    var IL_0000 = desc.AddLabel();
                    var IL_0001 = desc.AddLabel();
                    var IL_0002 = desc.AddLabel();
                    var IL_0003 = desc.AddLabel();
                    var IL_0004 = desc.AddLabel();
                    var IL_0005 = desc.AddLabel();
                    var IL_0007 = desc.AddLabel();
                    var IL_0008 = desc.AddLabel();
                    var IL_0009 = desc.AddLabel();
                    var IL_000a = desc.AddLabel();
                    var IL_000b = desc.AddLabel();
                    var IL_000c = desc.AddLabel();
                    var IL_000d = desc.AddLabel();
                    var IL_000e = desc.AddLabel();
                    var IL_000f = desc.AddLabel();
                    var IL_0010 = desc.AddLabel();
                    var IL_0011 = desc.AddLabel();
                    var IL_0012 = desc.AddLabel();
                    var IL_0013 = desc.AddLabel();
                    var IL_0015 = desc.AddLabel();
                    var IL_0016 = desc.AddLabel();
                    desc.Stream.AddRange(
                        NoOpCode.MarkLabel(IL_0000), OpCodeX.Ldc_I4_1(),         // IL_0000: ldc.i4.1
                        NoOpCode.MarkLabel(IL_0001), OpCodeX.Conv_I8(),          // IL_0001: conv.i8
                        NoOpCode.MarkLabel(IL_0002), OpCodeX.Stloc_0(),          // IL_0002: stloc.0
                        NoOpCode.MarkLabel(IL_0003), OpCodeX.Ldarg_0(),          // IL_0003: ldarg.0
                        NoOpCode.MarkLabel(IL_0004), OpCodeX.Stloc_1(),          // IL_0004: stloc.1
                                                                                 // // sequence point: hidden
                        NoOpCode.MarkLabel(IL_0005), OpCodeX.Br_S(IL_0010),      // IL_0005: br.s IL_0010
                                                                                 // // loop start (head: IL_0010)
                            NoOpCode.MarkLabel(IL_0007), OpCodeX.Ldloc_0(),      //     IL_0007: ldloc.0
                            NoOpCode.MarkLabel(IL_0008), OpCodeX.Ldloc_1(),      //     IL_0008: ldloc.1
                            NoOpCode.MarkLabel(IL_0009), OpCodeX.Mul(),          //     IL_0009: mul
                            NoOpCode.MarkLabel(IL_000a), OpCodeX.Stloc_0(),      //     IL_000a: stloc.0
                            NoOpCode.MarkLabel(IL_000b), OpCodeX.Ldloc_1(),      //     IL_000b: ldloc.1
                            NoOpCode.MarkLabel(IL_000c), OpCodeX.Ldc_I4_1(),     //     IL_000c: ldc.i4.1
                            NoOpCode.MarkLabel(IL_000d), OpCodeX.Conv_I8(),      //     IL_000d: conv.i8
                            NoOpCode.MarkLabel(IL_000e), OpCodeX.Sub(),          //     IL_000e: sub
                            NoOpCode.MarkLabel(IL_000f), OpCodeX.Stloc_1(),      //     IL_000f: stloc.1
                                                                                 //
                            NoOpCode.MarkLabel(IL_0010), OpCodeX.Ldloc_1(),      //     IL_0010: ldloc.1
                            NoOpCode.MarkLabel(IL_0011), OpCodeX.Ldc_I4_0(),     //     IL_0011: ldc.i4.0
                            NoOpCode.MarkLabel(IL_0012), OpCodeX.Conv_I8(),      //     IL_0012: conv.i8
                            NoOpCode.MarkLabel(IL_0013), OpCodeX.Bgt_S(IL_0007), //     IL_0013: bgt.s IL_0007
                                                                                 // // end loop
                                                                                 //
                        NoOpCode.MarkLabel(IL_0015), OpCodeX.Ldloc_0(),          // IL_0015: ldloc.0
                        NoOpCode.MarkLabel(IL_0016), OpCodeX.Ret());             // IL_0016: ret
                },
                typeof(long), new Type[] { typeof(long) });

            var sqrt = typeof(Math)
                .GetMethod(nameof(Math.Sqrt), BindingFlags.Public | BindingFlags.Static, new Type[] { typeof(double) })!;
            var atan2 = typeof(Math)
                .GetMethod(nameof(Math.Atan2), BindingFlags.Public | BindingFlags.Static, new Type[] { typeof(double), typeof(double) })!;
            var ctor = typeof(ValueTuple<double, double>).GetConstructor(new Type[] { typeof(double), typeof(double) })!;
            yield return CreateArgs(
                "Polar",
                gen => {
                    gen.Emit(OpCodes.Ldarg_0);
                    gen.Emit(OpCodes.Ldarg_0);
                    gen.Emit(OpCodes.Mul);
                    gen.Emit(OpCodes.Ldarg_1);
                    gen.Emit(OpCodes.Ldarg_1);
                    gen.Emit(OpCodes.Mul);
                    gen.Emit(OpCodes.Add);
                    gen.Emit(OpCodes.Call, sqrt);
                    gen.Emit(OpCodes.Ldarg_1);
                    gen.Emit(OpCodes.Ldarg_0);
                    gen.Emit(OpCodes.Call, atan2);
                    gen.Emit(OpCodes.Newobj, ctor);
                    gen.Emit(OpCodes.Ret);
                },
                desc => {
                    desc.Stream.Add(OpCodeX.Ldarg_0());
                    desc.Stream.Add(OpCodeX.Ldarg_0());
                    desc.Stream.Add(OpCodeX.Mul());
                    desc.Stream.Add(OpCodeX.Ldarg_1());
                    desc.Stream.Add(OpCodeX.Ldarg_1());
                    desc.Stream.Add(OpCodeX.Mul());
                    desc.Stream.Add(OpCodeX.Add());
                    desc.Stream.Add(OpCodeX.Call(sqrt));
                    desc.Stream.Add(OpCodeX.Ldarg_1());
                    desc.Stream.Add(OpCodeX.Ldarg_0());
                    desc.Stream.Add(OpCodeX.Call(atan2));
                    desc.Stream.Add(OpCodeX.Newobj(ctor));
                    desc.Stream.Add(OpCodeX.Ret());
                },
                typeof(ValueTuple<double, double>), new Type[] { typeof(double), typeof(double) });
            yield break;
        }
    }
}
