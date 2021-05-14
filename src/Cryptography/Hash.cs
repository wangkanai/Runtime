using System.Text;
using System.Security.Cryptography;

using JetBrains.Annotations;

namespace Wangkanai.Cryptography
{
    public static class Hash
    {
        public static string ToMd5([NotNull] this string value)
        {
            using var md5     = MD5.Create();
            var       input   = Encoding.ASCII.GetBytes(value);
            var       data    = md5.ComputeHash(input);
            var       builder = new StringBuilder();
            foreach (var index in data)
                builder.Append(index.ToString("x2"));

            return builder.ToString();
        }
    }
}