using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit.Internals;

internal static partial class OperandFormatter
{
    public static string ToString<T>(T value)
    {
        if(value is null)
        {
            return "<null>";
        }
        return Strategy<T>.Instance.ToString(value);
    }

    /*
    static OperandFormatter()
    {
        Strategy<LocalBuilder>.Instance = new LocalBuilder_();
        Strategy<ImmutableArray<Label>>.Instance = new LabelArray_();
        Strategy<ImmutableArray<LabelBuilder>>.Instance = new LabelBuilderArray_();
        Strategy<CallInfo>.Instance = new CallInfo_();
    }
    */

    private class Strategy<T>
    {
        public static Strategy<T> Instance { get; internal set; } = new Strategy<T>();

        public virtual string ToString(T operand) => operand!.ToString() ?? "";
    }

    [OperandFormatter]
    private sealed class LocalBuilder_ : Strategy<LocalBuilder>
    {
        public override string ToString(LocalBuilder operand) =>
            $"{operand.LocalIndex}";
    }

    [OperandFormatter]
    private sealed class LabelArray_ : Strategy<ImmutableArray<Label>>
    {
        public override string ToString(ImmutableArray<Label> opreand) =>
            $"({string.Join(", ", opreand.Select(static x => $"lbl_{LabelHelpers.GetId(x):X04}"))})";
    }

    [OperandFormatter]
    private sealed class LabelBuilderArray_ : Strategy<ImmutableArray<LabelBuilder>>
    {
        public override string ToString(ImmutableArray<LabelBuilder> opreand) =>
            $"({string.Join(", ", opreand)})";
    }

    [OperandFormatter]
    private sealed class CallInfo_ : Strategy<CallInfo>
    {
        public override string ToString(CallInfo operand) =>
            FormatterHelpers.ToString(operand.MethodInfo, operand.OptionalParameterTypes);
    }

    [OperandFormatter]
    private sealed class MethodInfo_ : Strategy<MethodInfo>
    {
        public override string ToString(MethodInfo operand) =>
            FormatterHelpers.ToString(operand);
    }
}


file static class FormatterHelpers
{
    public static string GetILName(this Assembly? assm)
    {
        var name = assm?.GetName().Name ?? "";
        if(name == "System.Private.CoreLib")
        {
            return "System.Runtime";
        }
        return name;
    }


    public static string GetILName(this Type? type, bool useShorthand = true)
    {
        static string @default(Type? t) => t?.FullName ?? "";

        if(!useShorthand)
        {
            return @default(type);
        }
        return type switch
        {
            { } when type == typeof(void) => "void",
            { } when type == typeof(bool) => "bool",
            { } when type == typeof(char) => "char",
            { } when type == typeof(sbyte) => "int8",
            { } when type == typeof(byte) => "uint8",
            { } when type == typeof(short) => "int16",
            { } when type == typeof(ushort) => "uint16",
            { } when type == typeof(int) => "int32",
            { } when type == typeof(uint) => "uint32",
            { } when type == typeof(long) => "int64",
            { } when type == typeof(ulong) => "uint64",
            { } when type == typeof(nint) => "native int",
            { } when type == typeof(nuint) => "native uint",
            { } when type == typeof(float) => "float32",
            { } when type == typeof(double) => "float64",
            { } when type == typeof(string) => "string",
            { } when type == typeof(object) => "object",
            { } when type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) =>
                $"{GetILName(type.GetGenericArguments()[0])}?",
            { } when type.IsByRef => $"{type.GetElementType().GetILName()}&",
            { } when type.IsPointer => $"{type.GetElementType().GetILName()}*",
            { } when type.IsArray => $"{type.GetElementType().GetILName()}[{new string(',', type.GetArrayRank() - 1)}]",
            { } when type.IsGenericType =>
                $"{type.FullName?.Split('`')[0]}<{string.Join(", ", type.GetGenericArguments().Select(static t =>GetILName(t)))}>",
            _ => @default(type),
        };
    }

    public static string ToString(MethodInfo operand, Type[]? optionalParameterTypes = null)
    {
        var methodInfo = operand;
        var sb = new StringBuilder();
        if(!methodInfo.IsStatic)
        {
            sb.Append("instance ");
        }
        sb.Append(methodInfo.ReturnType.GetILName());
        sb.Append(' ');
        if(methodInfo.DeclaringType is { } type)
        {
            sb.Append('[');
            sb.Append(type.Assembly.GetILName());
            sb.Append(']');
            sb.Append(type.GetILName(false));
            sb.Append("::");
        }
        sb.Append(methodInfo.Name);
        sb.Append('(');
        var parameters = methodInfo.GetParameters();
        for(int i = 0; i < parameters.Length; i++)
        {
            if(i > 0) sb.Append(", ");
            sb.Append(parameters[i].ParameterType.GetILName());
        }
        if(optionalParameterTypes is not null && optionalParameterTypes.Length > 0)
        {
            if(parameters.Length > 0) sb.Append(", ");
            sb.Append("...(");
            for(int i = 0; i < optionalParameterTypes.Length; i++)
            {
                if(i > 0) sb.Append(", ");
                sb.Append(optionalParameterTypes[i].GetILName());
            }
            sb.Append(')');
        }
        sb.Append(')');
        return sb.ToString();
    }
}
