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
        IReadOnlyDictionary<ArgumentDescriptor, int> Arguments { get; }
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
        Stack<IStackType> EvaluationStack { get; }
    }


    internal class ILGenerationState : IILEmissionState, IILValidationState
    {
        public MethodDescription Owner { get; }

        public int StreamPosition { get; internal set; }

        public IReadOnlyDictionary<ArgumentDescriptor, int> Arguments => _arguments;
        private readonly Dictionary<ArgumentDescriptor, int> _arguments;

        public IReadOnlyDictionary<LocalDescriptor, int> Locals => _locals;
        private readonly Dictionary<LocalDescriptor, int> _locals;

        public IReadOnlyDictionary<LabelDescriptor, Label> Labels => _labels;
        private readonly Dictionary<LabelDescriptor, Label> _labels;

        public ILGenerator Generator { get; }

        public Stack<IStackType> EvaluationStack { get; } = new Stack<IStackType>();


        public ILGenerationState(MethodDescription owner, ILGenerator generator)
        {
            Owner = owner;

            _arguments = new Dictionary<ArgumentDescriptor, int>();
            for(var i = 0; i < owner.Arguments.Count; ++i)
                _arguments.Add(owner.Arguments[i], i);
            
            _locals = new Dictionary<LocalDescriptor, int>();
            for(var i = 0; i < owner.Locals.Count; ++i)
            {
                generator.DeclareLocal(owner.Locals[i].VariableType);
                _locals.Add(owner.Locals[i], i);
            }

            _labels = new Dictionary<LabelDescriptor, Label>();
            for(var i = 0; i < owner.Labels.Count; ++i)
                _labels.Add(owner.Labels[i], generator.DefineLabel());

            Generator = generator;
        }
    }
}
