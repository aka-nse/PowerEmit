using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    public class CilGeneratorState
    {
        public CilMethodDescription Owner { get; }
        public ILGenerator Generator { get; }
        public int? StackBalance { get; private set; }
        public IReadOnlyDictionary<CilArgument, short> Arguments { get; }
        public IReadOnlyDictionary<CilLocal, int> Locals { get; }
        public IReadOnlyDictionary<CilLabel, Label> Labels { get; }


        public CilGeneratorState(CilMethodDescription owner, ILGenerator generator, bool validate)
        {
            Owner = owner;
            Generator = generator;
            Arguments = owner.Arguments.Select((arg, i) => (arg, i: (short)i)).ToDictionary(tpl => tpl.arg, tpl => tpl.i);
            Locals = owner.Locals.Select((loc, i) => (loc, i)).ToDictionary(tpl => tpl.loc, tpl => tpl.i);
            Labels = new ReadOnlyDictionary<CilLabel, Label>(owner.Labels.ToDictionary(cl => cl, cl => generator.DefineLabel()));
            StackBalance = validate ? (int?)0 : null;
        }


        internal void ProgressStackBalance(int? offset)
        {
            var newValue = StackBalance + offset;
            if((newValue ?? 0) < 0)
            {
                throw new ArgumentOutOfRangeException("Stack balance cannot be less than 0.");
            }
            StackBalance += offset;
        }
    }
}
