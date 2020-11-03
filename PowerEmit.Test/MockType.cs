using System;
using System.Reflection;

namespace PowerEmit
{
    public class MockType
    {
        public int MockField;
        public static FieldInfo FieldInfo { get; }
            = typeof(MockType).GetField(nameof(MockField))!;


        public static int MockStaticField;
        public static FieldInfo StaticFieldInfo { get; }
            = typeof(MockType).GetField(nameof(MockStaticField))!;


        public MockType() {}
        public static ConstructorInfo ConstructorInfo { get; }
            = typeof(MockType).GetConstructor(Array.Empty<Type>())!;


        public void MockMethod() {}
        public static MethodInfo MethodInfo { get; }
            = typeof(MockType).GetMethod(nameof(MockMethod))!;
    }
}
