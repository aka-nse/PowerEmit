using System.Reflection;
using System.Runtime.CompilerServices;

namespace PowerEmit.Disassemblers;

partial class ILDisassembler
{
    private partial class Entity
    {
        protected Module Module { get; }
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
            Module = method.Module;
            var body = method.GetMethodBody()!;
            _stream = body.GetILAsByteArray()!;
            Arguments = method
                .GetParameters()
                .Select(x => x.ParameterType)
                .ToList()
                .AsReadOnly();
            Locals = body
                .LocalVariables
                .Select(loc => loc.LocalType)
                .ToList()
                .AsReadOnly();
            _labels = [];
            _ilActions = [];
            Disassemble();
        }


        /// <summary>
        /// This constructor is defined for unit testing purposes.
        /// </summary>
        internal Entity(Module module, Type[] arguments, Type[] locals, byte[] byteStream)
        {
            Module = module;
            _stream = byteStream;
            Arguments = arguments;
            Locals = locals;
            _labels = [];
            _ilActions = [];
            Disassemble();
        }


        /// <summary>
        /// Disassembles the current instruction stream into a sequence of operations.
        /// </summary>
        /// <remarks>
        /// This method processes the instruction stream starting from the current position and converts each instruction into a corresponding operation.
        /// It continues until the end of the stream is reached.
        /// Labels are generated for each instruction index and operations are pushed to the operation stack.
        /// </remarks>
        private void Disassemble()
        {
            while(true)
            {
                var index = _current;
                if(index >= _stream.Length)
                {
                    break;
                }
                PushOperation(Directive.MarkLabel(GetOrAddLabel(index)));

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
                DisassembleNextOpCode(index, opcode);
            }
        }


        /// <summary>
        /// Retrieves an existing <see cref="LabelBuilder"/> for the specified stream index,
        /// or creates and adds a new one if it does not exist.
        /// </summary>
        /// <param name="streamIndex">The index of the stream for which to retrieve or create a label.</param>
        /// <returns>
        /// The <see cref="LabelBuilder"/> associated with the specified stream index.
        /// If no label exists for the given index, a new <see cref="LabelBuilder"/> is created, added, and returned.
        /// </returns>
        protected LabelBuilder GetOrAddLabel(int streamIndex)
            => _labels.TryGetValue(streamIndex, out var value)
                ? value
                : (_labels[streamIndex] = new LabelBuilder($"IL_{streamIndex:X04}"));


        /// <summary>
        /// Reads the next value from the IL stream and advances the current position.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T ReadStreamHead<T>()
            where T : unmanaged
        {
            var retval = Unsafe.As<byte, T>(ref _stream[_current]);
            _current += Unsafe.SizeOf<T>();
            return retval;
        }


        /// <summary>
        /// Adds the specified IL stream action to the internal collection and returns it.
        /// </summary>
        /// <param name="streamAction">The IL stream action to add. Cannot be null.</param>
        /// <returns>The same <see cref="IILStreamAction"/> instance that was added.</returns>
        protected IILStreamAction PushOperation(IILStreamAction streamAction)
        {
            _ilActions.Add(streamAction);
            return streamAction;
        }


        /// <summary>
        /// Disassembles the next operation code at the specified index.
        /// </summary>
        /// <remarks>This method is intended to be overridden in a derived class to provide custom
        /// disassembly logic.</remarks>
        /// <param name="currentIndex">The zero-based index of the current operation code to disassemble.</param>
        /// <param name="opcode">The operation code to be disassembled.</param>
        protected virtual partial void DisassembleNextOpCode(int currentIndex, short opcode);
    }
}