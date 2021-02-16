# PowerEmit

Reflection library for dynamic assemble / disassemble

## Concept

*PowerEmit* is designed as lightweight helper for dynamic IL generating.

*PowerEmit* improves quality of editor support and miscoding prevention while meeting with common usage for `ILGenerator`.
So this library does not provide high-level method generation.

## Demo

```CSharp
// common style
gen.Emit(OpCodes.Ldstr, "Hello, ");
gen.Emit(OpCodes.Ldarg_0);
gen.Emit(OpCodes.Ldstr, "!");
gen.Emit(OpCodes.Call, methodInfo_string_Concat);
gen.Emit(OpCodes.Call, methodInfo_Console_WriteLine);
gen.Emit(OpCodes.Ret);

// using PowerEmit on simple way
gen.Emit(Inst.Ldstr("Hello, "));
gen.Emit(Inst.Ldarg_0());
gen.Emit(Inst.Ldstr("!"));
gen.Emit(Inst.Call(methodInfo_string_Concat));
gen.Emit(Inst.Call(methodInfo_Console_WriteLine));
gen.Emit(Inst.Ret());

// collection is also available on PowerEmit
var list = new List<IILStreamAction> {
    Inst.Ldstr("Hello, "),
    Inst.Ldarg_0(),
    Inst.Ldstr("!"),
    Inst.Call(methodInfo_string_Concat),
    Inst.Call(methodInfo_Console_WriteLine),
    Inst.Ret(),
};
foreach(var action in list)
    gen.Emit(action);

// PowerEmit can coexist common style.
gen.Emit(Inst.Ldstr("Hello, "));
gen.Emit(OpCodes.Ldarg_0);
gen.Emit(Inst.Ldstr("!"));
gen.Emit(Inst.Call(methodInfo_string_Concat));
gen.Emit(Inst.Call(methodInfo_Console_WriteLine));
gen.Emit(OpCodes.Ret);
```

## Requirement

- .Net Standard *2.0*
  - System.Collections.Immutable *v5.0.0*
  - System.Memory *v4.5.4*
  - System.Reflection.Emit *v4.7.0*
  - System.RuntimeCompilerServices.Unsafe *v5.0.0*

## License

[Apache v2 License](./License.txt)

## Author

aka-nse
