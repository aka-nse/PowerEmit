using System;
using System.Collections.Generic;

namespace PowerEmit.Emit.Linq
{
    internal static class ReadOnlyList
    {

        public static int IndexOf<T>(this IReadOnlyList<T> list, T value)
            => list.IndexOf(x => Equals(x, value));


        public static int IndexOf<T>(this IReadOnlyList<T> list, Func<T, bool> filter)
        {
            var count = list.Count;
            for(var i = 0; i < count;++i)
                if(filter(list[i]))
                    return i;
            return -1;
        }


        public static int Sum(this IReadOnlyList<int> list)
        {
            var sum = 0;
            var count = list.Count;
            for(var i = 0 ; i < count ; ++i)
                sum += list[i];
            return sum;
        }


        public static IReadOnlyList<T> Skip<T>(this IReadOnlyList<T> list, int count)
        {
            if(list == null)
                throw new ArgumentNullException(nameof(list));
            if(count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if(list is SubList<T> sublist)
                return new SubList<T>(sublist.Entity, sublist.Start + count, sublist.Count - count);
            return new SubList<T>(list, count, list.Count - count);
        }


        public static IReadOnlyList<T> SkipWhile<T>(this IReadOnlyList<T> list,
                                                    Func<T, bool> filter)
            => list.Skip(list.IndexOf(filter));


        public static IReadOnlyList<T> Take<T>(this IReadOnlyList<T> list, int count)
        {
            if(list == null)
                throw new ArgumentNullException(nameof(list));
            if(count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if(list is SubList<T> sublist)
                return new SubList<T>(sublist.Entity, sublist.Start, Math.Min(sublist.Count, count));
            return new SubList<T>(list, 0, Math.Min(list.Count, count));
        }


        public static IReadOnlyList<T> TakeWhile<T>(this IReadOnlyList<T> list,
                                                    Func<T, bool> filter)
            => list.Take(list.IndexOf(filter));


        public static IReadOnlyList<TResult> Select<T, TResult>(
            this IReadOnlyList<T> list, Func<T, TResult> selector)
        {
            if(list == null)
                throw new ArgumentNullException(nameof(list));
            if(selector == null)
                throw new ArgumentNullException(nameof(selector));

            return new SelectList<T, TResult>(list, selector);
        }
    }
}
