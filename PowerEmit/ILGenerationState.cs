using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    /// <summary>
    /// Provides generating status for IL stream actions.
    /// </summary>
    public interface IILGenerationState
    {
        MethodDescription Owner { get; }
        int StreamPosition { get; }
        IReadOnlyDictionary<ArgumentDescriptor, short> Arguments { get; }
        IReadOnlyDictionary<LocalDescriptor, int> Locals { get; }
        IReadOnlyDictionary<LabelDescriptor, Label> Labels { get; }
    }

    /// <summary>
    /// Provides generating status including generator entity.
    /// </summary>
    public interface IILEmissionState : IILGenerationState
    {
        ILGenerator Generator { get; }
    }

    /// <summary>
    /// Provides generating status including evaluation stack behavior.
    /// </summary>
    public interface IILValidationState : IILGenerationState
    {
        Stack<StackType> EvaluationStack { get; }
    }


    internal class ILGenerationState : IILEmissionState, IILValidationState
    {
        public MethodDescription Owner { get; }

        public int StreamPosition { get; internal set; }

        public IReadOnlyDictionary<ArgumentDescriptor, short> Arguments { get; }

        public IReadOnlyDictionary<LocalDescriptor, int> Locals { get; }

        public IReadOnlyDictionary<LabelDescriptor, Label> Labels { get; }

        public ILGenerator Generator { get; }

        public Stack<StackType> EvaluationStack { get; } = new Stack<StackType>();


        public ILGenerationState(MethodDescription owner, ILGenerator generator)
        {
            Owner = owner;
            Arguments = owner.Arguments.Select((arg, i) => (arg, i: (short)i)).ToDictionary(tpl => tpl.arg, tpl => tpl.i);
            Locals = owner.Locals.Select((loc, i) => (loc, i)).ToDictionary(tpl =>
            {
                generator.DeclareLocal(tpl.loc.VariableType);
                return tpl.loc;
            }, tpl => tpl.i);
            Labels = new ReadOnlyDictionary<LabelDescriptor, Label>(owner.Labels.ToDictionary(cl => cl, cl => generator.DefineLabel()));
            Generator = generator;
        }
    }
}
