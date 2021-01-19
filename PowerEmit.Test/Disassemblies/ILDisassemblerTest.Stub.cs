using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PowerEmit.Disassemblies
{
    partial class ILDisassemblerTest
    {
        public class Stub
        {
            public static int Add(int x, int y) => x + y;
            public static MethodInfo AddInfo { get; }
                = typeof(Stub).GetMethod(nameof(Add), BindingFlags.Public | BindingFlags.Static)!;

            public static int Sum1(int[] source)
            {
                var retval = 0;
                foreach(var item in source)
                    retval = retval + item;
                return retval;
            }
            public static MethodInfo Sum1Info { get; }
                = typeof(Stub).GetMethod(nameof(Sum1), BindingFlags.Public | BindingFlags.Static)!;

            public static int Sum2(int[] source)
            {
                var retval = 0;
                foreach(var item in source)
                    retval = Add(retval, item);
                return retval;
            }
            public static MethodInfo Sum2Info { get; }
                = typeof(Stub).GetMethod(nameof(Sum2), BindingFlags.Public | BindingFlags.Static)!;
        }
    }
}
