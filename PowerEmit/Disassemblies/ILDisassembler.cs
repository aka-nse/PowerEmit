using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace PowerEmit.Disassemblies
{
    public partial class ILDisassembler
    {
        private int _current;
        protected MethodBase Method { get; }
        protected MethodBody Body { get; }
        private readonly byte[] _stream;
        private readonly Dictionary<int, LabelDescriptor> _labels;
        private readonly IReadOnlyList<ArgumentDescriptor> _arguments;
        private readonly IReadOnlyList<LocalDescriptor> _locals;
        private readonly List<IILStreamAction> _operations;


        public ILDisassembler(MethodBase method)
        {
            Method = method;
            Body = Method.GetMethodBody();
            _stream = Body.GetILAsByteArray();
            _arguments = method
                .GetParameters()
                .Select(x => new ArgumentDescriptor(x.ParameterType, x.Name))
                .ToList()
                .AsReadOnly();
            _locals = Body
                .LocalVariables
                .Select(loc => new LocalDescriptor(loc.LocalType, $"local{loc.LocalIndex}"))
                .ToList()
                .AsReadOnly();
            _labels = new Dictionary<int, LabelDescriptor>();
            _operations = new List<IILStreamAction>();
        }


        public MethodDescription Disassemble()
        {
            while(_current < _stream.Length)
            {
                var index = _current;
                var opcode = (short)_stream[index];
                if(opcode >= OpCodeConst.Prefix7)
                {
                    opcode = Unsafe.As<byte, short>(ref _stream[_current]);
                    _current += 2;
                }
                else
                {
                    _current += 1;
                }
                PushOperation(NoOpCode.MarkLabel(GetOrAddLabel(index)));
                DisassembleNextOpCode(index, opcode);
            }

            var desc = new MethodDescription(Method is MethodInfo mInfo ? mInfo.ReturnType : typeof(void));
            foreach(var arg in _arguments)
                desc.AddArgument(arg);
            foreach(var local in _locals)
                desc.AddLocal(local);
            foreach(var label in _labels.Values)
                desc.AddLabel(label);
            desc.Stream.AddRange(_operations);
            return desc;
        }

        protected LocalDescriptor GetLocal(int localIndex)
            => _locals[localIndex];

        protected ArgumentDescriptor GetArgument(int argIndex)
            => _arguments[argIndex];

        protected LabelDescriptor GetOrAddLabel(int streamIndex)
            => _labels.TryGetValue(streamIndex, out var value)
                ? value
                : (_labels[streamIndex] = new LabelDescriptor($"IL_{streamIndex:X04}"));


        protected T ReadStreamHead<T>()
            where T :unmanaged
        {
            var retval = Unsafe.As<byte, T>(ref _stream[_current]);
            _current += Unsafe.SizeOf<T>();
            return retval;
        }


        protected IILStreamAction PushOperation(IILStreamAction streamAction)
        {
            _operations.Add(streamAction);
            return streamAction;
        }


        // protected virtual void DisassembleNextOpCode(int currentIndex, short opcode);
    }
}
