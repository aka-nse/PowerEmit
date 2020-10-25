using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerEmit.Emit
{
    internal static class EnumExtensions
    {
        private static class Cache<TEnum>
            where TEnum : struct, Enum
        {
            public static TEnum[] Values { get; }


            public static FlagsAttribute? FlagsAttribute { get; }


            static Cache()
            {
                Values = (TEnum[])Enum.GetValues(typeof(TEnum));
                FlagsAttribute = typeof(TEnum)
                    .GetCustomAttributes(typeof(FlagsAttribute), false)
                    .FirstOrDefault()
                    as FlagsAttribute;
            }
        }


        public static TEnum? NullIfInvalid<TEnum>(this TEnum value)
            where TEnum : struct, Enum
        {
            if(Cache<TEnum>.FlagsAttribute == null)
            {
                var isValidValue = Cache<TEnum>.Values.Contains(value);
                return isValidValue ? (TEnum?)value : null;
            }
            else
            {
                return !double.TryParse(value.ToString(), out var _)
                    ? (TEnum?)value
                    : null;
            }
        }
    }
}
