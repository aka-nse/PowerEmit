using System;
using System.Collections;
using System.Collections.Generic;

namespace PowerEmit.Linq
{
    internal class SelectList<T, TResult> : IReadOnlyList<TResult>
    {

        private readonly IReadOnlyList<T> _source;

        private readonly Func<T, TResult> _selector;

        public TResult this[int index] => _selector(_source[index]);

        public int Count => _source.Count;


        public SelectList(IReadOnlyList<T> source, Func<T, TResult> selector)
        {
            _source = source;
            _selector = selector;
        }


        public IEnumerator<TResult> GetEnumerator()
        {
            var count = Count;
            for(var i = 0 ; i < count ; ++i)
                yield return this[i];
        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
