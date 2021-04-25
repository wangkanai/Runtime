using Wangkanai.Runtime.Extensions;

using Xunit;

namespace Wangkanai.Runtime.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Fact]
        public void Mixed()
        {
            Assert.True("sarinสาริน".IsUnicode());
        }

        [Fact]
        public void AsciiOnly()
        {
            Assert.False("123".IsUnicode());
            Assert.False("abc".IsUnicode());
            Assert.False("ABC".IsUnicode());
        }

        [Fact]
        public void UnicodeOnly()
        {
            Assert.True("สาริน".IsUnicode());
        }

        [Fact]
        public void DigitOnly()
        {
            Assert.False("123".IsUnicode());
        }

        [Fact]
        public void AlphabetOnly()
        {
            Assert.False("abc".IsUnicode());
            Assert.False("ABC".IsUnicode());
        }
    }
}