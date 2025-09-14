# PowerEmit

Reflection library for dynamic assemble / disassemble

## Concept

*PowerEmit* is designed as lightweight helper for dynamic IL generating.

*PowerEmit* improves quality of editor support and miscoding prevention while meeting with common usage for `ILGenerator`.
So this library does not provide high-level method generation.

## Demo

### Emit IL

- Equivalent code without PowerEmit

  ```CSharp
  internal class EmitIL_ConventionalStyle : EmitIL
  {
      protected override void BuildIL(
          ILGenerator gen,
          MethodInfo methodInfo_string_Concat,
          MethodInfo methodInfo_Console_WriteLine)
      {
          gen.Emit(OpCodes.Ldstr, "Hello, ");
          gen.Emit(OpCodes.Ldarg_0);
          gen.Emit(OpCodes.Call, methodInfo_string_Concat);
          gen.Emit(OpCodes.Ldstr, "!");
          gen.Emit(OpCodes.Call, methodInfo_string_Concat);
          gen.Emit(OpCodes.Call, methodInfo_Console_WriteLine);
          gen.Emit(OpCodes.Ret);
      }
  }
  ```

- using PowerEmit on simple way

  ```CSharp
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
  ```

- collection is available on PowerEmit

  ```CSharp
  internal class EmitIL_ListedPowerEmitAction : EmitIL
  {
      protected override void BuildIL(
          ILGenerator gen,
          MethodInfo methodInfo_string_Concat,
          MethodInfo methodInfo_Console_WriteLine)
      {
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
  ```

- PowerEmit can coexist conventional style

  ```CSharp
  internal class EmitIL_MixedStyle : EmitIL
  {
      protected override void BuildIL(
          ILGenerator gen,
          MethodInfo methodInfo_string_Concat,
          MethodInfo methodInfo_Console_WriteLine)
      {
          gen.Emit(Inst.Ldstr("Hello, "));
          gen.Emit(OpCodes.Ldarg_0);
          gen.Emit(Inst.Call(methodInfo_string_Concat));
          gen.Emit(Inst.Ldstr("!"));
          gen.Emit(Inst.Call(methodInfo_string_Concat));
          gen.Emit(Inst.Call(methodInfo_Console_WriteLine));
          gen.Emit(OpCodes.Ret);
      }
  }
  ```

### Disassembler

*PowerEmit* provides disassembler.

```CSharp
using System.Reflection;
using PowerEmit.Disassemblers;

internal class Disassemble : ISampleCase
{
    public void Run()
    {
        var methodInfo = typeof(Disassemble)
            .GetMethod(
                nameof(SampleMethod),
                BindingFlags.Public | BindingFlags.Static)!;

        var disassembled = ILDisassembler.Instance.Disassemble(methodInfo);
        Console.Write(disassembled);
    }

    public static int SampleMethod(int x, int y, int z)
    {
        if(z < 0)
        {
            return x * y;
        }
        for(var i = 0; i < z; ++i)
        {
            x += y;
        }
        return x;
    }
}
```

### Deoptimizer

*PowerEmit* provides deoptimizer.
By using with disassembler, deoptimizer enables to edit IL method safely.

```CSharp
using System.Reflection;
using PowerEmit.Disassemblers;

internal class Deoptimize : ISampleCase
{
    public void Run()
    {
        var methodInfo = typeof(Deoptimize)
            .GetMethod(
                nameof(SampleMethod),
                BindingFlags.Public | BindingFlags.Static)!;

        var disassembled = ILDisassembler.Instance.Disassemble(methodInfo);
        var deoptimized = ILDeoptimizer.Instance.Deoptimize(disassembled);
        Console.Write(deoptimized);
    }

    public static int SampleMethod(int x, int y, int z)
    {
        if(z < 0)
        {
            return x * y;
        }
        for(var i = 0; i < z; ++i)
        {
            x += y;
        }
        return x;
    }
}
```

## Requirement

- .Net Standard *2.0*
  - System.Collections.Immutable *[9.0.9,)*
  - System.Memory *[4.6.0,)*
  - System.Reflection.Emit *[4.7.0,)*
  - System.RuntimeCompilerServices.Unsafe *[6.1.0,)*

## License

[Apache v2 License](./License.txt)

## Author

aka-nse
