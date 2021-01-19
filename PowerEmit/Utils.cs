using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerEmit
{
    internal static class Utils
    {
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            var tmp = rhs;
            rhs = lhs;
            lhs = tmp;
        }


        public static T[] Pop<T>(this Stack<T> stack, int count)
        {
            if(stack.Count >= count)
            {
                var values = new T[count];
                for(var i = 0; i < count; ++i)
                    values[i] = stack.Pop();
                return values;
            }
            else
                throw new ArgumentException();
        }


        public static bool IsNullableAssignableFrom(this Type variableType, Type? valueType)
        {
            if(variableType is null)
                throw new ArgumentNullException(nameof(variableType));

            if(valueType is null)
                return !variableType.IsValueType && !variableType.IsPointer && !variableType.IsByRef;
            else
                return variableType.IsAssignableFrom(valueType);
        }



    }
}
