using System;
using System.Globalization;
using System.Text;
using JetBrains.Annotations;

namespace Wangkanai.Runtime.Extensions
{
    public static class StringExtensions
    {
        [ContractAnnotation("null => true")]
        public static bool IsNullOrEmpty(this string input)
            => string.IsNullOrEmpty(input);
        
        [ContractAnnotation("null => true")]
        public static bool IsNullOrWhiteSpace(this string input)
            => string.IsNullOrWhiteSpace(input);

        public static bool IsUnicode(this string input)
        {
            var asciiBytesCount   = Encoding.ASCII.GetByteCount(input);
            var unicodeBytesCount = Encoding.UTF8.GetByteCount(input);
            return asciiBytesCount != unicodeBytesCount;
        }

        public static string EnsureEndsWith(this string input, char c)
            => input.EnsureEndsWith(c, StringComparison.Ordinal);

        public static string EnsureEndsWith(this string input, char c, StringComparison comparison)
        {
            Check.NotNull(input, nameof(input));

            return input.EndsWith(c.ToString(), comparison) 
                       ? input 
                       : input + c;
        }

        public static string EnsureEndsWith(this string input, char c, bool ignoreCase, CultureInfo culture)
        {
            Check.NotNull(input, nameof(input));

            return input.EndsWith(c.ToString(culture), ignoreCase, culture) 
                       ? input 
                       : input + c;
        }

        public static string EnsureStartsWith(this string input, char c)
            => input.EnsureStartsWith(c, StringComparison.Ordinal);
        
        public static string EnsureStartsWith(this string input, char c, StringComparison comparison)
        {
            Check.NotNull(input, nameof(input));

            return input.StartsWith(c.ToString(), comparison)
                       ? input
                       : c + input;
        }

        public static string EnsureStartsWith(this string input, char c, bool ignoreCase, CultureInfo culture)
        {
            Check.NotNull(input, nameof(input));

            return input.StartsWith(c.ToString(culture), ignoreCase, culture)
                       ? input
                       : c + input;
        }
    }
}