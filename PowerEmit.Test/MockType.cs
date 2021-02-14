using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PowerEmit
{
    public class MockType
    {
        public static Type Type { get; } = typeof(MockType);
        public static FieldInfo StaticFieldInfo { get; } = typeof(MockType).GetField(nameof(StaticField))!;
        public static FieldInfo InstanceFieldInfo { get; } = typeof(MockType).GetField(nameof(InstanceField))!;
        public static ConstructorInfo ConstructorInfo { get; } = typeof(MockType).GetConstructor(Array.Empty<Type>())!;
        public static MethodInfo MethodInfo { get; } = typeof(MockType).GetMethod(nameof(Method))!;
        public static MethodInfo VarargsMethodInfo { get; } = typeof(MockType).GetMethod(nameof(VarargsMethod))!;


        public static int StaticField;
        public int InstanceField;
        public MockType() { }
        public void Method() { }
        public void VarargsMethod(__arglist) { }
    }
}
