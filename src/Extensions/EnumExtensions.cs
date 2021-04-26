using System;
using System.Collections.Generic;
using System.Linq;

namespace Wangkanai.Runtime.Extensions
{
    public static class EnumExtensions
    {
        public static bool Contains<T>(this string agent, T flags)
            where T : Enum
            => EnumValues<T>.TryGetSingleName(flags, out var value) && value != null
                   ? agent.Contains(value, StringComparison.Ordinal)
                   : flags.GetFlags().Any(item => agent.Contains(ToStringInvariant<T>(item), StringComparison.Ordinal));

        public static string ToStringInvariant<T>(this T value)
            where T : Enum
            => EnumValues<T>.GetName(value);

        public static IEnumerable<T> GetFlags<T>(this T value)
            where T : Enum
        {
            var values = EnumValues<T>.Values;

            foreach (var item in values)
                if (value.HasFlag(item))
                    yield return item;
        }
    }

    public static class EnumValues<T> where T : Enum
    {
        public static readonly T[] Values;

        private static readonly Dictionary<T, string> Names = new();

        static EnumValues()
        {
            Values = (T[]) Enum.GetValues(typeof(T));
            foreach (var value in Values)
                Names.Add(value, value.ToString().ToLowerInvariant());
        }

        public static string GetName(T value)
            => Names.TryGetValue(value, out var result)
                   ? result
                   : string.Join(',', value.GetFlags().Select(x => Names[x]));

        public static bool TryGetSingleName(T value, out string? result)
            => Names.TryGetValue(value, out result);
    }
}