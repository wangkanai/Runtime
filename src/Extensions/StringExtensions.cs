using System;
using System.Globalization;
using System.Text;

namespace Wangkanai.Runtime.Extensions
{
    public static class StringExtensions
    {
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
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (input.EndsWith(c.ToString(), comparison))
                return input;

            return input + c;
        }

        public static string EnsureEndsWith(this string input, char c, bool ignoreCase, CultureInfo culture)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (input.EndsWith(c.ToString(culture), ignoreCase, culture))
                return input;

            return input + c;
        }
    }
}