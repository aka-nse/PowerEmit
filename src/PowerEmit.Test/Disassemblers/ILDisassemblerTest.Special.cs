using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PowerEmit.Disassemblers;

public partial class ILDisassemblerTest
{
    [Fact]
    public void Disassemble_Jmp_Invalid()
    {
        var builder = new Builder(typeof(void), []);
        builder.ILGenerator.Emit(OpCodes.Jmp, MockType.ConstructorInfo);
        var method = builder.GetBuiltILBytes()!;
        Assert.Throws<InvalidOperationException>(() => Accessor.Disassemble(ILDisassembler.Instance, builder.Module, [], [], method));
    }

    [Fact]
    public void Disassemble_Callvirt_Invalid()
    {
        var builder = new Builder(typeof(void), []);
        builder.ILGenerator.Emit(OpCodes.Callvirt, MockType.ConstructorInfo);
        var method = builder.GetBuiltILBytes()!;
        Assert.Throws<InvalidOperationException>(() => Accessor.Disassemble(ILDisassembler.Instance, builder.Module, [], [], method));
    }

    [Fact]
    public void Disassemble_Newobj_Invalid()
    {
        var builder = new Builder(typeof(void), []);
        builder.ILGenerator.Emit(OpCodes.Newobj, MockType.MethodInfo);
        var method = builder.GetBuiltILBytes()!;
        Assert.Throws<InvalidOperationException>(() => Accessor.Disassemble(ILDisassembler.Instance, builder.Module, [], [], method));
    }

    [Fact]
    public void Disassemble_Ldftn_Invalid()
    {
        var builder = new Builder(typeof(void), []);
        builder.ILGenerator.Emit(OpCodes.Ldftn, MockType.ConstructorInfo);
        var method = builder.GetBuiltILBytes()!;
        Assert.Throws<InvalidOperationException>(() => Accessor.Disassemble(ILDisassembler.Instance, builder.Module, [], [], method));
    }

    [Fact]
    public void Disassemble_Ldvirtftn_Invalid()
    {
        var builder = new Builder(typeof(void), []);
        builder.ILGenerator.Emit(OpCodes.Ldvirtftn, MockType.ConstructorInfo);
        var method = builder.GetBuiltILBytes()!;
        Assert.Throws<InvalidOperationException>(() => Accessor.Disassemble(ILDisassembler.Instance, builder.Module, [], [], method));
    }

    [Fact]
    public void Disassemble_Ldtoken_Type()
    {
        var builder = new Builder(typeof(void), []);
        builder.ILGenerator.Emit(OpCodes.Ldtoken, typeof(MockType));
        var method = builder.GetBuiltILBytes()!;
        var content = Accessor.Disassemble(ILDisassembler.Instance, builder.Module, [], [], method);
        var operation = Assert.Single(content.ILActions.OfType<IInst>());
        var ldtoken = Assert.IsType<Inst<Type>>(operation);
        Assert.Equal(OpCodes.Ldtoken, ldtoken.OpCode);
        Assert.Equal(typeof(MockType), ldtoken.Operand);
    }

    [Fact]
    public void Disassemble_Ldtoken_Method()
    {
        var builder = new Builder(typeof(void), []);
        builder.ILGenerator.Emit(OpCodes.Ldtoken, MockType.MethodInfo);
        var method = builder.GetBuiltILBytes()!;
        var content = Accessor.Disassemble(ILDisassembler.Instance, builder.Module, [], [], method);
        var operation = Assert.Single(content.ILActions.OfType<IInst>());
        var ldtoken = Assert.IsType<Inst<MethodInfo>>(operation);
        Assert.Equal(OpCodes.Ldtoken, ldtoken.OpCode);
        Assert.Equal(MockType.MethodInfo, ldtoken.Operand);
    }

    [Fact]
    public void Disassemble_Ldtoken_Field()
    {
        var builder = new Builder(typeof(void), []);
        builder.ILGenerator.Emit(OpCodes.Ldtoken, MockType.InstanceFieldInfo);
        var method = builder.GetBuiltILBytes()!;
        var content = Accessor.Disassemble(ILDisassembler.Instance, builder.Module, [], [], method);
        var operation = Assert.Single(content.ILActions.OfType<IInst>());
        var ldtoken = Assert.IsType<Inst<FieldInfo>>(operation);
        Assert.Equal(OpCodes.Ldtoken, ldtoken.OpCode);
        Assert.Equal(MockType.InstanceFieldInfo, ldtoken.Operand);
    }

    [Fact]
    public void Disassemble_Ldtoken_Invalid()
    {
        var builder = new Builder(typeof(void), []);
        builder.ILGenerator.Emit(OpCodes.Ldtoken, MockType.ConstructorInfo);
        var method = builder.GetBuiltILBytes()!;
        Assert.Throws<InvalidOperationException>(() => Accessor.Disassemble(ILDisassembler.Instance, builder.Module, [], [], method));
    }

    [Fact]
    public void Disassemble_Calli()
    {
        // calli is not supported in current virsion.
        var builder = new Builder(typeof(void), []);
        builder.ILGenerator.EmitCalli(OpCodes.Calli, System.Reflection.CallingConventions.VarArgs, typeof(void), [], []);
        var method = builder.GetBuiltILBytes()!;
        Assert.Throws<NotSupportedException>(() => Accessor.Disassemble(ILDisassembler.Instance, builder.Module, [], [], method));
    }

    [Fact]
    public void Disassemble_Leave()
    {
        var builder = new Builder(typeof(void), []);
        var label = builder.ILGenerator.DefineLabel();
        builder.ILGenerator.Emit(OpCodes.Leave, label);
        builder.ILGenerator.MarkLabel(label);
        builder.ILGenerator.Emit(OpCodes.Nop);
        var method = builder.GetBuiltILBytes()!;
        var content = Accessor.Disassemble(ILDisassembler.Instance, builder.Module, [], [], method);
        var ilOps = content.ILActions.ToArray();
        var leave = Assert.IsType<Inst<LabelBuilder>>(ilOps[1]);
        var targetLabel = Assert.IsType<MarkLabel>(ilOps[2]);
        Assert.Equal(OpCodes.Leave, leave.OpCode);
        Assert.Same(targetLabel.LabelBuilder, leave.Operand);
    }

    [Fact]
    public void Disassemble_Leave_S()
    {
        var builder = new Builder(typeof(void), []);
        var label = builder.ILGenerator.DefineLabel();
        builder.ILGenerator.Emit(OpCodes.Leave_S, label);
        builder.ILGenerator.MarkLabel(label);
        builder.ILGenerator.Emit(OpCodes.Nop);
        var method = builder.GetBuiltILBytes()!;
        var content = Accessor.Disassemble(ILDisassembler.Instance, builder.Module, [], [], method);
        var ilOps = content.ILActions.ToArray();
        var leave = Assert.IsType<Inst<LabelBuilder>>(ilOps[1]);
        var targetLabel = Assert.IsType<MarkLabel>(ilOps[2]);
        Assert.Equal(OpCodes.Leave_S, leave.OpCode);
        Assert.Same(targetLabel.LabelBuilder, leave.Operand);
    }

    [Fact]
    public void Disassemble_InvalidIL()
    {
        byte[] stream = [0xFF, 0xFF];
        Assert.Throws<InvalidOperationException>(() => Accessor.Disassemble(ILDisassembler.Instance, typeof(object).Module, [], [], stream));
    }
}

file static class Accessor
{
    [UnsafeAccessor(UnsafeAccessorKind.Method)]
    internal static extern MethodContent Disassemble(ILDisassembler disassembler, Module module, Type[] arguments, Type[] locals, byte[] byteStream);
}
