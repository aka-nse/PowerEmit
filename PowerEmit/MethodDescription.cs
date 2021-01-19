using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

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
        /// Gets a max stack size of this method.
        /// </summary>
        public int MaxStack =>
#warning not implemented
            -1;

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
        /// <param name="variableName"></param>
        /// <returns></returns>
        public ArgumentDescriptor AddArgument(Type type, string variableName)
            => AddArgument(new ArgumentDescriptor(type, variableName));


        internal ArgumentDescriptor AddArgument(ArgumentDescriptor arg)
        {
            _arguments.Add(arg);
            return arg;
        }

        /// <summary>
        /// Adds a new local variable for this method.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="variableName"></param>
        /// <returns></returns>
        public LocalDescriptor AddLocal(Type type, string variableName)
            => AddLocal(new LocalDescriptor(type, variableName));


        internal LocalDescriptor AddLocal(LocalDescriptor local)
        {
            _locals.Add(local);
            return local;
        }


        /// <summary>
        /// Adds a new label entry for this method.
        /// </summary>
        /// <returns></returns>
        public LabelDescriptor AddLabel()
            => AddLabel(new LabelDescriptor($"AnonymousLabel_{Labels.Count:X04}"));

        /// <summary>
        /// Adds a new label entry for this method.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public LabelDescriptor AddLabel(string name)
            => AddLabel(new LabelDescriptor(name));


        internal LabelDescriptor AddLabel(LabelDescriptor label)
        {
            _labels.Add(label);
            return label;
        }


        /// <summary>
        /// Writes out operations to method builder.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="validates"></param>
        public void BuildMethod(MethodBuilder method, bool validates = true)
        {
            method.SetReturnType(ReturnType);
            method.SetParameters(Arguments.Select(x => x.VariableType).ToArray());
            BuildMethod(method.GetILGenerator(), validates);
        }


        /// <summary>
        /// Writes out operations to IL generator.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="validates"></param>
        public void BuildMethod(ILGenerator generator, bool validates = true)
        {
            var state = new ILGenerationState(this, generator);
            foreach(var op in Stream)
            {
                op.Emit(state);
                if(validates)
                {
                    op.ValidateStack(state);
                }
                ++state.StreamPosition;
            }
        }


        /// <summary>
        /// (Do not use. This method is place holder.)
        /// Invokes this method description dynamically.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public object? Invoke(object? obj, object?[] args)
        {
            throw new NotSupportedException();
        }


        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{ReturnType} AnonymousMethod");
            if(Arguments.Count > 0)
            {
                sb.AppendLine("(");
                sb.AppendLine(string.Join(
                    "," + Environment.NewLine,
                    Arguments.Select(arg => $"        {arg.VariableType} {arg.Name}")
                    ));
                sb.Append("    )");
            }
            else
            {
                sb.Append("()");
            }
            sb.AppendLine(" cil managed");
            sb.AppendLine("{");
            sb.AppendLine($"    .maxstack {MaxStack}");
            if(Locals.Count > 0)
            {
                sb.AppendLine($"    .locals init(");
                sb.AppendLine(string.Join(
                    "," + Environment.NewLine,
                    Locals.Select((loc, i) => $"        [{i}] {loc.VariableType} {loc.Name}")
                    ));
                sb.AppendLine($"    )");
            }
            sb.AppendLine();

            var prefix = "    ";
            foreach(var action in Stream)
            {
                if(action is IILStreamLabelMark)
                {
                    sb.Append(prefix + action.ToString());
                    prefix = " ";
                }
                else
                {
                    sb.AppendLine(prefix + action.ToString());
                    prefix = "    ";
                }
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
