using System;
using System.Collections.Generic;
using System.Text;

namespace PowerEmit
{
    internal static class Disposable
    {
        private sealed class EmptyDisposable : IDisposable
        {
            public void Dispose() { }
        }
        private sealed class AnonymousDisposable : IDisposable
        {
            private readonly Action _dispose;
            public AnonymousDisposable(Action dispose) => _dispose = dispose;
            public void Dispose() => _dispose();
        }

        public static IDisposable Empty { get; } = new EmptyDisposable();

        public static IDisposable Create(Action dispose)
            => new AnonymousDisposable(dispose);
    }
}
