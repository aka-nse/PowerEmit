using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class PushOperationTest
    {
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
            static Action<CilMethodDescription> createActualBefore(Action<CilMethodDescription, CilLabel> push, int offset)
                => desc =>
                {
                    var label = new CilLabel();
                    desc.Push_MarkLabel(label);
                    for(var i = 0; i < offset; ++i)
                        desc.Push_Nop();
                    push(desc, label);
                };
            static Action<CilMethodDescription> createActualAfter(Action<CilMethodDescription, CilLabel> push, int offset)
                => desc =>
                {
                    var label = new CilLabel();
                    push(desc, label);
                    for(var i = 0; i < offset; ++i)
                        desc.Push_Nop();
                    desc.Push_MarkLabel(label);
                };

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Br_S,
                    createExpectedBefore(OpCodes.Br_S, i),
                    createActualBefore((desc, label) => desc.Push_Br_S(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Br_S,
                    createExpectedAfter(OpCodes.Br_S, i),
                    createActualAfter((desc, label) => desc.Push_Br_S(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Brfalse_S,
                    createExpectedBefore(OpCodes.Brfalse_S, i),
                    createActualBefore((desc, label) => desc.Push_Brfalse_S(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Brfalse_S,
                    createExpectedAfter(OpCodes.Brfalse_S, i),
                    createActualAfter((desc, label) => desc.Push_Brfalse_S(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Brtrue_S,
                    createExpectedBefore(OpCodes.Brtrue_S, i),
                    createActualBefore((desc, label) => desc.Push_Brtrue_S(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Brtrue_S,
                    createExpectedAfter(OpCodes.Brtrue_S, i),
                    createActualAfter((desc, label) => desc.Push_Brtrue_S(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Beq_S,
                    createExpectedBefore(OpCodes.Beq_S, i),
                    createActualBefore((desc, label) => desc.Push_Beq_S(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Beq_S,
                    createExpectedAfter(OpCodes.Beq_S, i),
                    createActualAfter((desc, label) => desc.Push_Beq_S(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Bge_S,
                    createExpectedBefore(OpCodes.Bge_S, i),
                    createActualBefore((desc, label) => desc.Push_Bge_S(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Bge_S,
                    createExpectedAfter(OpCodes.Bge_S, i),
                    createActualAfter((desc, label) => desc.Push_Bge_S(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Bgt_S,
                    createExpectedBefore(OpCodes.Bgt_S, i),
                    createActualBefore((desc, label) => desc.Push_Bgt_S(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Bgt_S,
                    createExpectedAfter(OpCodes.Bgt_S, i),
                    createActualAfter((desc, label) => desc.Push_Bgt_S(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Ble_S,
                    createExpectedBefore(OpCodes.Ble_S, i),
                    createActualBefore((desc, label) => desc.Push_Ble_S(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Ble_S,
                    createExpectedAfter(OpCodes.Ble_S, i),
                    createActualAfter((desc, label) => desc.Push_Ble_S(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Blt_S,
                    createExpectedBefore(OpCodes.Blt_S, i),
                    createActualBefore((desc, label) => desc.Push_Blt_S(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Blt_S,
                    createExpectedAfter(OpCodes.Blt_S, i),
                    createActualAfter((desc, label) => desc.Push_Blt_S(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Bne_Un_S,
                    createExpectedBefore(OpCodes.Bne_Un_S, i),
                    createActualBefore((desc, label) => desc.Push_Bne_Un_S(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Bne_Un_S,
                    createExpectedAfter(OpCodes.Bne_Un_S, i),
                    createActualAfter((desc, label) => desc.Push_Bne_Un_S(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Bge_Un_S,
                    createExpectedBefore(OpCodes.Bge_Un_S, i),
                    createActualBefore((desc, label) => desc.Push_Bge_Un_S(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Bge_Un_S,
                    createExpectedAfter(OpCodes.Bge_Un_S, i),
                    createActualAfter((desc, label) => desc.Push_Bge_Un_S(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Bgt_Un_S,
                    createExpectedBefore(OpCodes.Bgt_Un_S, i),
                    createActualBefore((desc, label) => desc.Push_Bgt_Un_S(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Bgt_Un_S,
                    createExpectedAfter(OpCodes.Bgt_Un_S, i),
                    createActualAfter((desc, label) => desc.Push_Bgt_Un_S(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Ble_Un_S,
                    createExpectedBefore(OpCodes.Ble_Un_S, i),
                    createActualBefore((desc, label) => desc.Push_Ble_Un_S(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Ble_Un_S,
                    createExpectedAfter(OpCodes.Ble_Un_S, i),
                    createActualAfter((desc, label) => desc.Push_Ble_Un_S(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Blt_Un_S,
                    createExpectedBefore(OpCodes.Blt_Un_S, i),
                    createActualBefore((desc, label) => desc.Push_Blt_Un_S(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Blt_Un_S,
                    createExpectedAfter(OpCodes.Blt_Un_S, i),
                    createActualAfter((desc, label) => desc.Push_Blt_Un_S(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Br,
                    createExpectedBefore(OpCodes.Br, i),
                    createActualBefore((desc, label) => desc.Push_Br(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Br,
                    createExpectedAfter(OpCodes.Br, i),
                    createActualAfter((desc, label) => desc.Push_Br(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Brfalse,
                    createExpectedBefore(OpCodes.Brfalse, i),
                    createActualBefore((desc, label) => desc.Push_Brfalse(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Brfalse,
                    createExpectedAfter(OpCodes.Brfalse, i),
                    createActualAfter((desc, label) => desc.Push_Brfalse(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Brtrue,
                    createExpectedBefore(OpCodes.Brtrue, i),
                    createActualBefore((desc, label) => desc.Push_Brtrue(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Brtrue,
                    createExpectedAfter(OpCodes.Brtrue, i),
                    createActualAfter((desc, label) => desc.Push_Brtrue(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Beq,
                    createExpectedBefore(OpCodes.Beq, i),
                    createActualBefore((desc, label) => desc.Push_Beq(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Beq,
                    createExpectedAfter(OpCodes.Beq, i),
                    createActualAfter((desc, label) => desc.Push_Beq(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Bge,
                    createExpectedBefore(OpCodes.Bge, i),
                    createActualBefore((desc, label) => desc.Push_Bge(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Bge,
                    createExpectedAfter(OpCodes.Bge, i),
                    createActualAfter((desc, label) => desc.Push_Bge(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Bgt,
                    createExpectedBefore(OpCodes.Bgt, i),
                    createActualBefore((desc, label) => desc.Push_Bgt(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Bgt,
                    createExpectedAfter(OpCodes.Bgt, i),
                    createActualAfter((desc, label) => desc.Push_Bgt(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Ble,
                    createExpectedBefore(OpCodes.Ble, i),
                    createActualBefore((desc, label) => desc.Push_Ble(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Ble,
                    createExpectedAfter(OpCodes.Ble, i),
                    createActualAfter((desc, label) => desc.Push_Ble(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Blt,
                    createExpectedBefore(OpCodes.Blt, i),
                    createActualBefore((desc, label) => desc.Push_Blt(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Blt,
                    createExpectedAfter(OpCodes.Blt, i),
                    createActualAfter((desc, label) => desc.Push_Blt(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Bne_Un,
                    createExpectedBefore(OpCodes.Bne_Un, i),
                    createActualBefore((desc, label) => desc.Push_Bne_Un(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Bne_Un,
                    createExpectedAfter(OpCodes.Bne_Un, i),
                    createActualAfter((desc, label) => desc.Push_Bne_Un(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Bge_Un,
                    createExpectedBefore(OpCodes.Bge_Un, i),
                    createActualBefore((desc, label) => desc.Push_Bge_Un(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Bge_Un,
                    createExpectedAfter(OpCodes.Bge_Un, i),
                    createActualAfter((desc, label) => desc.Push_Bge_Un(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Bgt_Un,
                    createExpectedBefore(OpCodes.Bgt_Un, i),
                    createActualBefore((desc, label) => desc.Push_Bgt_Un(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Bgt_Un,
                    createExpectedAfter(OpCodes.Bgt_Un, i),
                    createActualAfter((desc, label) => desc.Push_Bgt_Un(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Ble_Un,
                    createExpectedBefore(OpCodes.Ble_Un, i),
                    createActualBefore((desc, label) => desc.Push_Ble_Un(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Ble_Un,
                    createExpectedAfter(OpCodes.Ble_Un, i),
                    createActualAfter((desc, label) => desc.Push_Ble_Un(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Blt_Un,
                    createExpectedBefore(OpCodes.Blt_Un, i),
                    createActualBefore((desc, label) => desc.Push_Blt_Un(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Blt_Un,
                    createExpectedAfter(OpCodes.Blt_Un, i),
                    createActualAfter((desc, label) => desc.Push_Blt_Un(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 127, 255, 256, 1024})
            {
                yield return CreateArgs(
                    OpCodes.Leave,
                    createExpectedBefore(OpCodes.Leave, i),
                    createActualBefore((desc, label) => desc.Push_Leave(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Leave,
                    createExpectedAfter(OpCodes.Leave, i),
                    createActualAfter((desc, label) => desc.Push_Leave(label), i)
                );
            }

            foreach(var i in new []{0, 1, 2, 16, 126})
            {
                yield return CreateArgs(
                    OpCodes.Leave_S,
                    createExpectedBefore(OpCodes.Leave_S, i),
                    createActualBefore((desc, label) => desc.Push_Leave_S(label), i)
                );
                yield return CreateArgs(
                    OpCodes.Leave_S,
                    createExpectedAfter(OpCodes.Leave_S, i),
                    createActualAfter((desc, label) => desc.Push_Leave_S(label), i)
                );
            }
        }
    }
}
