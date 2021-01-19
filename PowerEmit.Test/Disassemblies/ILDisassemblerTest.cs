using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using Xunit;

namespace PowerEmit.Disassemblies
{
    public partial class ILDisassemblerTest
    {
        public virtual ILDisassembler GetDisassembler(MethodInfo methodInfo)
            => new ILDisassembler(methodInfo);


        public static IEnumerable<object[]> Test1Args()
        {
            object[] core(int x, int y) => new object[] { x, y };

            yield return core(0, 0);
            yield return core(1, 0);
            yield return core(0, 1);
            yield return core(1, 1);
            yield return core(1, -1);
            yield return core(-1, 1);
            yield return core(382, 997);
            yield return core(453, 155);
            yield return core(-6354, 1806);
            yield return core(-8856, -612);
            yield return core(834269732, -104623876);
            yield break;
        }


        [Theory]
        [MemberData(nameof(Test1Args))]
        public void Test1(int x, int y)
        {
            var builder = new Builder(typeof(int), new[] { typeof(int), typeof(int) });
            var disassembler = GetDisassembler(Stub.AddInfo);
            var desc = disassembler.Disassemble();
            desc.BuildMethod(builder.Method);
            var method = builder.BuiltMethod;
            Assert.Equal(Stub.AddInfo.GetMethodBody()!.GetILAsByteArray(), builder.GetILBytes());
            var deleg = method.CreateDelegate(typeof(Func<int, int, int>)) as Func<int, int, int>;
            Assert.Equal(Stub.Add(x, y), deleg!(x, y));
        }

        public static IEnumerable<object[]> Test2Args()
        {
            object[] core(params int[] x) => new object[] { x };

            yield return core(0, 0);
            yield return core(0, 0, 0);
            yield return core(1, 0);
            yield return core(0, 1);
            yield return core(12, -7, 4);
            yield return core(13127, -32, 0, 157, 3778);
            yield return core(234, 64, -432, -312, 8731, 83, 13561, 9800, -3768, -3189);
            yield break;
        }


        [Theory]
        [MemberData(nameof(Test2Args))]
        public void Test2(int[] x)
        {
            var builder = new Builder(typeof(int), new[] { typeof(int[]), });
            var disassembler = GetDisassembler(Stub.Sum1Info);
            var desc = disassembler.Disassemble();
            desc.BuildMethod(builder.Method);
            var method = builder.BuiltMethod;
            var deleg = method.CreateDelegate(typeof(Func<int[], int>)) as Func<int[], int>;
            Assert.Equal(Stub.Sum1(x), deleg!(x));
            Assert.Equal(Stub.Sum1Info.GetMethodBody()!.GetILAsByteArray(), builder.GetILBytes());
        }
    }
}
