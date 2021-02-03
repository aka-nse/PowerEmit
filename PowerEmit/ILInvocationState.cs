using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerEmit
{
    public interface IILInvocationState
    {
        MethodDescription Owner { get; }
        int CurrentStreamPosition { get; }
        IDictionary<ArgumentDescriptor, object?> Arguments { get; }
        IDictionary<LocalDescriptor, object?> Locals { get; }
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

        public IDictionary<ArgumentDescriptor, object?> Arguments { get; }

        public IDictionary<LocalDescriptor, object?> Locals { get; }

        public Stack<StackValue> EvaluationStack { get; }

        public object? ReturnValue { get; private set; }

        public object? ThrownError { get; private set; }


        public ILInvocationState(MethodDescription owner, object?[] arguments)
        {
            Owner = owner;
            if(owner.Arguments.Count != arguments.Length)
                throw new ArgumentException();

            Arguments = new Dictionary<ArgumentDescriptor, object?>();
            for(var i = 0; i < owner.Arguments.Count; ++i)
                Arguments.Add(owner.Arguments[i], arguments[i]);

            Locals = new Dictionary<LocalDescriptor, object?>();
            for(var i = 0; i < owner.Locals.Count; ++i)
                Locals.Add(owner.Locals[i], null);

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
