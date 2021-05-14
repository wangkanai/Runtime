using System;
using System.Collections.Generic;
using System.Linq;

namespace Wangkanai.Runtime.Extensions
{
    public static class EnumExtensions
    {
        public static bool Contains<T>(this string agent, T flags) where T : Enum
            => EnumValues<T>.TryGetSingleName(flags, out var value) && value != null
                   ? agent.Contains(value, StringComparison.Ordinal)
                   : flags.GetFlags()
                          .Any(item => agent.Contains(ToStringInvariant(item), StringComparison.Ordinal));

        public static string ToStringInvariant<T>(this T value) where T : Enum
            => EnumValues<T>.GetName(value);

        public static IEnumerable<T> GetFlags<T>(this T value) where T : Enum
            => EnumValues<T>.Values.Where(item => value.HasFlag(item));
    }
}