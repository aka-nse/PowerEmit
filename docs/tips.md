# Tips for implementations of PowerEmit

## `Ldarg` specifications for index arguments that are larger than `short.MaxValue`

In originally spec, `Ldarg` accept 0 - 65535 arguments.
But `ILGenerator.Emit()` for `Ldarg` accepts only a overload of `ILGenerator.Emit(OpCode, short)`.
The 2nd argument of `Emit` should be instant casted value to short from actual index number.


