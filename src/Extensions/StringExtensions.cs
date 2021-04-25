using System.Text;

namespace Wangkanai.Runtime.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string input)
            => string.IsNullOrWhiteSpace(input);

        public static bool IsUnicode(this string input)
        {
            var acciiBytesCount   = Encoding.ASCII.GetByteCount(input);
            var unicodeBytesCount = Encoding.UTF8.GetByteCount(input);
            return acciiBytesCount != unicodeBytesCount;
        }
    }
}