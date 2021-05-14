using System;
using System.Collections.Generic;
using System.Linq;

namespace Wangkanai.Extensions
{
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
        {
            var flags = value.GetFlags().Select(x => Names[x]);
            return Names.TryGetValue(value, out var result)
                       ? result
                       : string.Join(',', flags);
        }

        public static bool TryGetSingleName(T value, out string result)
            => Names.TryGetValue(value, out result);
    }
}