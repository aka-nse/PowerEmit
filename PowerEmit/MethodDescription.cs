using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using PowerEmit.Linq;

namespace PowerEmit
{
    /// <summary>
    /// Provides a feature to define method operation by CIL.
    /// </summary>
    public partial class MethodDescription
    {
        /// <summary>
        /// Gets a type of return value of this method.
        /// </summary>
        public Type ReturnType { get; }

        /// <summary>
        /// Gets a sequence of argument informations of this method.
        /// </summary>
        public IReadOnlyList<ArgumentDescriptor> Arguments => _arguments.AsReadOnly();
        private readonly List<ArgumentDescriptor> _arguments = new List<ArgumentDescriptor>();

        /// <summary>
        /// Gets a sequence of local variable informations of this method.
        /// </summary>
        public IReadOnlyList<LocalDescriptor> Locals => _locals.AsReadOnly();
        private readonly List<LocalDescriptor> _locals = new List<LocalDescriptor>();

        /// <summary>
        /// Gets a sequence of ILGenerator state updating operations of this method.
        /// </summary>
        public ILStreamActionCollection Stream { get; } = new ILStreamActionCollection();

        /// <summary>
        /// Gets a sequence of branch target labels of this method.
        /// </summary>
        public IReadOnlyList<LabelDescriptor> Labels => _labels.AsReadOnly();
        private readonly List<LabelDescriptor> _labels = new List<LabelDescriptor>();

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="returnType"></param>
        public MethodDescription(Type returnType)
        {
            ReturnType = returnType;
        }

        /// <summary>
        /// Adds a new argument for this method.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public ArgumentDescriptor AddArgument(ArgumentDescriptor arg)
        {
            _arguments.Add(arg);
            return arg;
        }

        /// <summary>
        /// Adds a new local variable for this method.
        /// </summary>
        /// <param name="local"></param>
        /// <returns></returns>
        public LocalDescriptor AddLocal(LocalDescriptor local)
        {
            _locals.Add(local);
            return local;
        }


        /// <summary>
        /// Writes out operations to method builder.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="validate">
        /// If true, the builder will validate logic as possible;
        /// it includes stack balance and method calling signature.
        /// </param>
        public void BuildMethod(MethodBuilder method, bool validate = true)
        {
            method.SetReturnType(ReturnType);
            method.SetParameters(Arguments.Select(x => x.VariableType).ToArray());
            var gen = method.GetILGenerator();
            var state = new ILGeneratorState(this, gen, validate);
            foreach(var op in Stream)
            {
                op.Emit(state);
            }
            if(validate && ((state.StackBalance ?? 0) != 0))
            {
                throw new InvalidOperationException("Stack balance at end must be 0.");
            }
        }
    }
}
