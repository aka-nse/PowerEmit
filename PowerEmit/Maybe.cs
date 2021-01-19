using System;
using System.Collections.Generic;
using System.Text;

namespace PowerEmit
{
    public interface IMaybe<out T>
    {
    }

    public interface IJust<out T> : IMaybe<T>
    {
        T Value { get; }
    }

    public interface INone<out T> : IMaybe<T>
    {
    }

    public static class Maybe
    {
        private sealed class _Just<T> : IJust<T>
        {
            public T Value { get; }
            public _Just(T value) => Value = value;
        }
        private sealed class _None<T> : INone<T>
        {
            public static _None<T> Instance { get; } = new _None<T>();
            private _None() { }
        }

        public static IJust<T> Just<T>(T value)
            => new _Just<T>(value);

        public static INone<T> None<T>()
            => _None<T>.Instance;

        public static IMaybe<T> NotNull<T>(T? value)
            where T : struct
            => value.HasValue ? Just(value.Value) : None<T>();

        public static IMaybe<T> NotNull<T>(T? value)
            where T : class
            => value is not null ? Just(value) : None<T>();

        public static IMaybe<T> NotNull<T>(this IMaybe<T?> maybe)
            where T : class
            => maybe is IJust<T?> just ? NotNull(just.Value) : None<T>();

        public static bool Try<T>(this IMaybe<T> maybe, out T value)
        {
            if(maybe is IJust<T> just)
            {
                value = just.Value;
                return true;
            }
            else
            {
                value = default!;
                return false;
            }
        }

        public static T? GetOrDefault<T>(this IMaybe<T> maybe, T @default = default)
            => maybe is IJust<T> just ? just.Value : @default;
    }
}
