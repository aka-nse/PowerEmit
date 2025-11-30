using System;
using System.Collections.Generic;
using System.Text;

namespace PowerEmit;

internal struct HashHelper
{
    private uint _current;

    public HashHelper Append<T>(T? value)
    {
        var h = value?.GetHashCode() ?? 0;
        _current = (_current << 5) + _current ^ (uint)h;
        return this;
    }

    public HashHelper AppendRange<T>(IEnumerable<T?> values)
    {
        if (values is null)
        {
            _current = (_current << 5) + _current;
            return this;
        }
        foreach (var v in values)
        {
            Append(v);
        }
        return this;
    }

    public readonly int ToHashCode() => (int)_current;

    public static int Combine<T1>(T1? v1) =>
        new HashHelper()
            .Append(v1)
            .ToHashCode();

    public static int Combine<T1, T2>(T1? v1, T2? v2) =>
        new HashHelper()
            .Append(v1)
            .Append(v2)
            .ToHashCode();

    public static int Combine<T1, T2, T3>(T1? v1, T2? v2, T3? v3) =>
        new HashHelper()
            .Append(v1)
            .Append(v2)
            .Append(v3)
            .ToHashCode();

    public static int Combine<T1, T2, T3, T4>(T1? v1, T2? v2, T3? v3, T4? v4) =>
        new HashHelper()
            .Append(v1)
            .Append(v2)
            .Append(v3)
            .Append(v4)
            .ToHashCode();
}
