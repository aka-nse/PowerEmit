using System;
using System.Collections;
using System.Collections.Generic;

namespace PowerEmit.Linq
{
    internal class SubList<T> : IReadOnlyList<T>
    {

        public IReadOnlyList<T> Entity { get; }


        public int Start { get; }


        public int Count { get; }


        public int End { get; }


        public T this[int index] => Entity[Map(index)];


        public SubList(IReadOnlyList<T> entity, int start, int count)
        {
            Entity = entity;
            Start = start >= 0 ? start : throw new ArgumentOutOfRangeException(nameof(start));
            Count = count >= 0 ? count : throw new ArgumentOutOfRangeException(nameof(count));
            End = Start + Count;
        }


        public IEnumerator<T> GetEnumerator()
        {

            for(var i = Start ; i < End ; ++i)
            {
                yield return Entity[i];
            }
        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        private int Map(int index)
        {
            var relIndex = Start + index;
            if((uint)Count < (uint)relIndex)
                throw new ArgumentOutOfRangeException(nameof(index));
            return relIndex;
        }
    }
}
