using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace PowerEmit.Disassemblers
{
    partial class ILDisassembler
    {
        private partial class Entity
        {
            public MethodBase Method { get; }
            protected MethodBody Body { get; }
            private readonly byte[] _stream;
            private int _current;

            // key: byte position
            private readonly Dictionary<int, LabelBuilder> _labels;
            private readonly List<IILStreamAction> _ilActions;

            public IReadOnlyList<Type> Arguments { get; }
            public IReadOnlyList<Type> Locals { get; }
            public IReadOnlyDictionary<int, LabelBuilder> Labels => _labels;
            public IReadOnlyList<IILStreamAction> ILActions => _ilActions;

            public Entity(MethodBase method)
            {
                Method = method;
                Body = Method.GetMethodBody();
                _stream = Body.GetILAsByteArray();
                Arguments = method
                    .GetParameters()
                    .Select(x => x.ParameterType)
                    .ToList()
                    .AsReadOnly();
                Locals = Body
                    .LocalVariables
                    .Select(loc => loc.LocalType)
                    .ToList()
                    .AsReadOnly();
                _labels = new Dictionary<int, LabelBuilder>();
                _ilActions = new List<IILStreamAction>();
                Disassemble();
            }



            private void Disassemble()
            {
                while(_current < _stream.Length)
                {
                    var index = _current;
                    var opcode = (short)_stream[index];
                    if(opcode >= OpCodeConst.Prefix7)
                    {
                        opcode = (short)((_stream[index] << 8) + _stream[index + 1]);
                        _current += 2;
                    }
                    else
                    {
                        _current += 1;
                    }
                    PushOperation(Directive.MarkLabel(GetOrAddLabel(index)));
                    DisassembleNextOpCode(index, opcode);
                }
            }

            protected LabelBuilder GetOrAddLabel(int streamIndex)
                => _labels.TryGetValue(streamIndex, out var value)
                    ? value
                    : (_labels[streamIndex] = new LabelBuilder($"IL_{streamIndex:X04}"));


            protected T ReadStreamHead<T>()
                where T : unmanaged
            {
                var retval = Unsafe.As<byte, T>(ref _stream[_current]);
                _current += Unsafe.SizeOf<T>();
                return retval;
            }


            protected IILStreamAction PushOperation(IILStreamAction streamAction)
            {
                _ilActions.Add(streamAction);
                return streamAction;
            }


            protected virtual partial void DisassembleNextOpCode(int currentIndex, short opcode);
        }
    }
}
