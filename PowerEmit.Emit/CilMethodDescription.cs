using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using PowerEmit.Emit.Linq;

namespace PowerEmit.Emit
{
    /// <summary>
    /// Provides a feature to define method operation by CIL.
    /// </summary>
    public partial class CilMethodDescription
    {
        /// <summary>
        /// Gets a type of return value of this method.
        /// </summary>
        public Type ReturnType { get; }

        /// <summary>
        /// Gets a sequence of argument informations of this method.
        /// </summary>
        public IReadOnlyList<CilArgument> Arguments => _arguments.AsReadOnly();
        private readonly List<CilArgument> _arguments = new List<CilArgument>();

        /// <summary>
        /// Gets a sequence of local variable informations of this method.
        /// </summary>
        public IReadOnlyList<CilLocal> Locals => _locals.AsReadOnly();
        private readonly List<CilLocal> _locals = new List<CilLocal>();

        /// <summary>
        /// Gets a sequence of ILGenerator state updating operations of this method.
        /// </summary>
        public IReadOnlyList<ICilGeneratorAction> Operations => _operations.AsReadOnly();
        private readonly List<ICilGeneratorAction> _operations = new List<ICilGeneratorAction>();

        /// <summary>
        /// Gets a sequence of branch target labels of this method.
        /// </summary>
        public IReadOnlyList<CilLabel> Labels => _labels.AsReadOnly();
        private readonly List<CilLabel> _labels = new List<CilLabel>();

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="returnType"></param>
        public CilMethodDescription(Type returnType)
        {
            ReturnType = returnType;
        }

        /// <summary>
        /// Adds a new argument for this method.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public CilArgument AddArgument(CilArgument arg)
        {
            _arguments.Add(arg);
            return arg;
        }

        /// <summary>
        /// Adds a new local variable for this method.
        /// </summary>
        /// <param name="local"></param>
        /// <returns></returns>
        public CilLocal AddLocal(CilLocal local)
        {
            _locals.Add(local);
            return local;
        }


        /// <summary>
        /// Searches operation instance that marks the specified label.
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public MarkLabel? FindLabelMark(CilLabel label)
        {
            return _operations
                .Select(x => x as MarkLabel)
                .FirstOrDefault(x => x?.Label == label);
        }


        /// <summary>
        /// Pushes a label marking operation to ILGenerator operation table.
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public MarkLabel Push_MarkLabel(CilLabel label)
        {
            var result = new MarkLabel(label);
            _operations.Add(result);
            _labels.Add(label);
            return result;
        }


        /// <summary>
        /// Push a user defined operation to ILGenerator operation table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ilLogic"></param>
        /// <returns></returns>
        public T PushLogic<T>(T ilLogic)
            where T : ICilGeneratorAction
        {
            _operations.Add(ilLogic);
            return ilLogic;
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
            var state = new CilGeneratorState(this, gen, validate);
            foreach(var op in Operations)
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
