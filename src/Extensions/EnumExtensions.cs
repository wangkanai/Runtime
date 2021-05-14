using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Wangkanai.Runtime.Extensions
{
    public static class EnumExtensions
    {
        public static string ToStringInvariant<T>(this T value) where T : Enum
            => EnumValues<T>.GetName(value);
        
        public static bool Contains<T>(this string agent, T flags) where T : Enum
            => EnumValues<T>.TryGetSingleName(flags, out var value) && value != null
                   ? agent.Contains(value, StringComparison.Ordinal)
                   : flags.GetFlags()
                          .Any(item => agent.Contains(ToStringInvariant(item), StringComparison.Ordinal));
        
        public static IEnumerable<T> GetFlags<T>(this T value) where T : Enum
            => EnumValues<T>.Values.Where(item => value.HasFlag(item));

        public static string GetDescription(this Enum generic)
        {
            var type   = generic.GetType();
            var member = type.GetMember(generic.ToString());
            if (member != null && member.Length > 0)
            {
                var attributes = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Count() > 0)
                    return ((DescriptionAttribute) attributes.ElementAt(0)).Description;
            }

            return generic.ToString();
        }
    }
}