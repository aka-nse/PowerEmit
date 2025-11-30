using System.Reflection;
using System.Reflection.Emit;
using PowerEmit;

internal abstract class EmitIL : ISampleCase
{
    public void Run()
    {
        var dynamicMethod = new DynamicMethod(
            $"SayHello_{Guid.NewGuid():N}",
            typeof(void),
            [typeof(string)]);
        var gen = dynamicMethod.GetILGenerator();

        var methodInfo_string_Concat = typeof(string)
            .GetMethod(
                nameof(string.Concat),
                BindingFlags.Public | BindingFlags.Static,
                [typeof(string), typeof(string)])!;
        var methodInfo_Console_WriteLine = typeof(Console)
            .GetMethod(
                nameof(Console.WriteLine),
                BindingFlags.Public | BindingFlags.Static,
                [typeof(string)])!;

        BuildIL(gen, methodInfo_string_Concat, methodInfo_Console_WriteLine);

        var sayHello = dynamicMethod.CreateDelegate<Action<string>>();
        sayHello("World");
    }

    protected abstract void BuildIL(
        ILGenerator gen,
        MethodInfo methodInfo_string_Concat,
        MethodInfo methodInfo_Console_WriteLine);
}

internal class EmitIL_ConventionalStyle : EmitIL
{
    protected override void BuildIL(
         ILGenerator gen,
         MethodInfo methodInfo_string_Concat,
         MethodInfo methodInfo_Console_WriteLine)
    {
        // conventional style, without PowerEmit
        gen.Emit(OpCodes.Ldstr, "Hello, ");
        gen.Emit(OpCodes.Ldarg_0);
        gen.Emit(OpCodes.Call, methodInfo_string_Concat);
        gen.Emit(OpCodes.Ldstr, "!");
        gen.Emit(OpCodes.Call, methodInfo_string_Concat);
        gen.Emit(OpCodes.Call, methodInfo_Console_WriteLine);
        gen.Emit(OpCodes.Ret);
    }
}

internal class EmitIL_SimpleStyle : EmitIL
{
    protected override void BuildIL(
         ILGenerator gen,
         MethodInfo methodInfo_string_Concat,
         MethodInfo methodInfo_Console_WriteLine)
    {
        // using PowerEmit on simple way
        gen.Emit(Inst.Ldstr("Hello, "));
        gen.Emit(Inst.Ldarg_0());
        gen.Emit(Inst.Call(methodInfo_string_Concat));
        gen.Emit(Inst.Ldstr("!"));
        gen.Emit(Inst.Call(methodInfo_string_Concat));
        gen.Emit(Inst.Call(methodInfo_Console_WriteLine));
        gen.Emit(Inst.Ret());
    }
}

internal class EmitIL_ListedPowerEmitAction : EmitIL
{
    protected override void BuildIL(
         ILGenerator gen,
         MethodInfo methodInfo_string_Concat,
         MethodInfo methodInfo_Console_WriteLine)
    {
        // collection is available on PowerEmit
        IILStreamAction[] actions = [
            Inst.Ldstr("Hello, "),
            Inst.Ldarg_0(),
            Inst.Call(methodInfo_string_Concat),
            Inst.Ldstr("!"),
            Inst.Call(methodInfo_string_Concat),
            Inst.Call(methodInfo_Console_WriteLine),
            Inst.Ret(),
        ];
        foreach(var action in actions)
        {
            gen.Emit(action);
        }
    }
}

internal class EmitIL_MixedStyle : EmitIL
{
    protected override void BuildIL(
         ILGenerator gen,
         MethodInfo methodInfo_string_Concat,
         MethodInfo methodInfo_Console_WriteLine)
    {
        // PowerEmit can coexist common style.
        gen.Emit(Inst.Ldstr("Hello, "));
        gen.Emit(OpCodes.Ldarg_0);
        gen.Emit(Inst.Call(methodInfo_string_Concat));
        gen.Emit(Inst.Ldstr("!"));
        gen.Emit(Inst.Call(methodInfo_string_Concat));
        gen.Emit(Inst.Call(methodInfo_Console_WriteLine));
        gen.Emit(OpCodes.Ret);
    }
}
