#nullable enable
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Xunit;

namespace PowerEmit
{
    public partial class PushOperationTest
    {
        [Theory]
        [MemberData(nameof(TestArgs_Branch))]
        private void PushTest_Branch(string testname, Action<ILGenerator> expected, Action<MethodDescription> actual, Type? returnType = null, Type[]? parameterTypes = null)
            => PushTestCore(testname, expected, actual, returnType, parameterTypes);


        public static IEnumerable<object[]> TestArgs_Branch()
        {
            static Action<ILGenerator> createExpectedBefore(OpCode opcode, int offset)
                => gen =>
                {
                    var label = gen.DefineLabel();
                    gen.MarkLabel(label);
                    for(var i = 0; i < offset; ++i)
                        gen.Emit(OpCodes.Nop);
                    gen.Emit(opcode, label);
                };
            static Action<ILGenerator> createExpectedAfter(OpCode opcode, int offset)
                => gen =>
                {
                    var label = gen.DefineLabel();
                    gen.Emit(opcode, label);
                    for(var i = 0; i < offset; ++i)
                        gen.Emit(OpCodes.Nop);
                    gen.MarkLabel(label);
                };
            static Action<MethodDescription> createActualBefore(Action<MethodDescription, LabelDescriptor> push, int offset)
                => desc =>
                {
                    var label = new LabelDescriptor();
                    desc.Stream.Add(NoOpCode.MarkLabel(label));
                    for(var i = 0; i < offset; ++i)
                        desc.Stream.Add(OpCodeX.Nop());
                    push(desc, label);
                };
            static Action<MethodDescription> createActualAfter(Action<MethodDescription, LabelDescriptor> push, int offset)
                => desc =>
                {
                    var label = new LabelDescriptor();
                    push(desc, label);
                    for(var i = 0; i < offset; ++i)
                        desc.Stream.Add(OpCodeX.Nop());
                    desc.Stream.Add(NoOpCode.MarkLabel(label));
                };

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Br_S,
                    createExpectedBefore(OpCodes.Br_S, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Br_S(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Br_S,
                    createExpectedAfter(OpCodes.Br_S, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Br_S(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Brfalse_S,
                    createExpectedBefore(OpCodes.Brfalse_S, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Brfalse_S(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Brfalse_S,
                    createExpectedAfter(OpCodes.Brfalse_S, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Brfalse_S(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Brtrue_S,
                    createExpectedBefore(OpCodes.Brtrue_S, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Brtrue_S(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Brtrue_S,
                    createExpectedAfter(OpCodes.Brtrue_S, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Brtrue_S(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Beq_S,
                    createExpectedBefore(OpCodes.Beq_S, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Beq_S(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Beq_S,
                    createExpectedAfter(OpCodes.Beq_S, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Beq_S(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Bge_S,
                    createExpectedBefore(OpCodes.Bge_S, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Bge_S(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Bge_S,
                    createExpectedAfter(OpCodes.Bge_S, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Bge_S(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Bgt_S,
                    createExpectedBefore(OpCodes.Bgt_S, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Bgt_S(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Bgt_S,
                    createExpectedAfter(OpCodes.Bgt_S, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Bgt_S(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Ble_S,
                    createExpectedBefore(OpCodes.Ble_S, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Ble_S(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Ble_S,
                    createExpectedAfter(OpCodes.Ble_S, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Ble_S(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Blt_S,
                    createExpectedBefore(OpCodes.Blt_S, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Blt_S(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Blt_S,
                    createExpectedAfter(OpCodes.Blt_S, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Blt_S(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Bne_Un_S,
                    createExpectedBefore(OpCodes.Bne_Un_S, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Bne_Un_S(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Bne_Un_S,
                    createExpectedAfter(OpCodes.Bne_Un_S, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Bne_Un_S(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Bge_Un_S,
                    createExpectedBefore(OpCodes.Bge_Un_S, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Bge_Un_S(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Bge_Un_S,
                    createExpectedAfter(OpCodes.Bge_Un_S, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Bge_Un_S(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Bgt_Un_S,
                    createExpectedBefore(OpCodes.Bgt_Un_S, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Bgt_Un_S(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Bgt_Un_S,
                    createExpectedAfter(OpCodes.Bgt_Un_S, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Bgt_Un_S(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Ble_Un_S,
                    createExpectedBefore(OpCodes.Ble_Un_S, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Ble_Un_S(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Ble_Un_S,
                    createExpectedAfter(OpCodes.Ble_Un_S, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Ble_Un_S(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Blt_Un_S,
                    createExpectedBefore(OpCodes.Blt_Un_S, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Blt_Un_S(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Blt_Un_S,
                    createExpectedAfter(OpCodes.Blt_Un_S, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Blt_Un_S(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Br,
                    createExpectedBefore(OpCodes.Br, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Br(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Br,
                    createExpectedAfter(OpCodes.Br, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Br(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Brfalse,
                    createExpectedBefore(OpCodes.Brfalse, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Brfalse(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Brfalse,
                    createExpectedAfter(OpCodes.Brfalse, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Brfalse(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Brtrue,
                    createExpectedBefore(OpCodes.Brtrue, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Brtrue(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Brtrue,
                    createExpectedAfter(OpCodes.Brtrue, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Brtrue(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Beq,
                    createExpectedBefore(OpCodes.Beq, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Beq(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Beq,
                    createExpectedAfter(OpCodes.Beq, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Beq(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Bge,
                    createExpectedBefore(OpCodes.Bge, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Bge(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Bge,
                    createExpectedAfter(OpCodes.Bge, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Bge(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Bgt,
                    createExpectedBefore(OpCodes.Bgt, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Bgt(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Bgt,
                    createExpectedAfter(OpCodes.Bgt, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Bgt(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Ble,
                    createExpectedBefore(OpCodes.Ble, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Ble(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Ble,
                    createExpectedAfter(OpCodes.Ble, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Ble(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Blt,
                    createExpectedBefore(OpCodes.Blt, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Blt(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Blt,
                    createExpectedAfter(OpCodes.Blt, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Blt(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Bne_Un,
                    createExpectedBefore(OpCodes.Bne_Un, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Bne_Un(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Bne_Un,
                    createExpectedAfter(OpCodes.Bne_Un, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Bne_Un(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Bge_Un,
                    createExpectedBefore(OpCodes.Bge_Un, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Bge_Un(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Bge_Un,
                    createExpectedAfter(OpCodes.Bge_Un, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Bge_Un(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Bgt_Un,
                    createExpectedBefore(OpCodes.Bgt_Un, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Bgt_Un(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Bgt_Un,
                    createExpectedAfter(OpCodes.Bgt_Un, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Bgt_Un(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Ble_Un,
                    createExpectedBefore(OpCodes.Ble_Un, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Ble_Un(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Ble_Un,
                    createExpectedAfter(OpCodes.Ble_Un, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Ble_Un(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Blt_Un,
                    createExpectedBefore(OpCodes.Blt_Un, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Blt_Un(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Blt_Un,
                    createExpectedAfter(OpCodes.Blt_Un, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Blt_Un(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Leave,
                    createExpectedBefore(OpCodes.Leave, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Leave(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Leave,
                    createExpectedAfter(OpCodes.Leave, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Leave(label)), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Leave_S,
                    createExpectedBefore(OpCodes.Leave_S, i),
                    createActualBefore((desc, label) => desc.Stream.Add(OpCodeX.Leave_S(label)), i)
                );
                yield return CreateArgs(
                    OpCodes.Leave_S,
                    createExpectedAfter(OpCodes.Leave_S, i),
                    createActualAfter((desc, label) => desc.Stream.Add(OpCodeX.Leave_S(label)), i)
                );
            }
        }
    }
}
