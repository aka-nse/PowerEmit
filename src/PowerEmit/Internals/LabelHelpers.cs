using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace PowerEmit.Internals;

internal static class LabelHelpers
{
    public static int GetId(this Label label)
    {
#if NET9_0_OR_GREATER
        return label.Id;
#else
        return Unsafe.As<Label, int>(ref label);
#endif
    }
}
