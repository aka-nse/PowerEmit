using System;
using System.Collections.Generic;

namespace PowerEmit
{
    public interface IILInvocationState
    {
        MethodDescription Owner { get; }
        int CurrentStreamPosition { get; }
        object?[] Arguments { get; }
        object?[] Locals { get; }
        Stack<StackValue> EvaluationStack { get; }
        object? ReturnValue { get; }
        void SetReturnValue(object? value);
        void ThrowError(object error);
        void MoveTo(int newStreamPosition);
    }

    public sealed class ILInvocationState : IILInvocationState
    {
        public MethodDescription Owner { get; }

        public int CurrentStreamPosition { get; private set; }

        public object?[] Arguments { get; }

        public object?[] Locals { get; }

        public Stack<StackValue> EvaluationStack { get; }

        public object? ReturnValue { get; private set; }

        public object? ThrownError { get; private set; }


        public ILInvocationState(MethodDescription owner, object?[] arguments)
        {
            Owner = owner;
            Arguments = arguments;
            Locals = new object?[Owner.Locals.Count];
            EvaluationStack = new Stack<StackValue>();
        }

        public void SetReturnValue(object? value)
            => ReturnValue = value;

        public void ThrowError(object error)
            => ThrownError = error;

        public void MoveTo(int newStreamPosition)
            => CurrentStreamPosition = newStreamPosition;
    }
}
