using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2
{
    [Collection("InputData")]
    public class UnitTest1
    {
        private string[] _ids;

        public UnitTest1(InputFixture input)
        {
            _ids = input.Identifiers;
        }

        [Fact]
        public void abcdef_has_only_single_chars()
        {
            var result = IdStats.CountForChecksum("abcdef");
            result.two.Should().BeFalse();
            result.three.Should().BeFalse();
        }

        [Fact]
        public void bababc_has_1_two_and_1_three()
        {
            var result = IdStats.CountForChecksum("bababc");
            result.two.Should().BeTrue();
            result.three.Should().BeTrue();
        }

        [Fact]
        public void abbcde_has_1_two_and_0_three()
        {
            var result = IdStats.CountForChecksum("abbcde");
            result.two.Should().BeTrue();
            result.three.Should().BeFalse();
        }

        [Fact]
        public void abcccd_has_0_two_and_1_three()
        {
            var result = IdStats.CountForChecksum("abcccd");
            result.two.Should().BeFalse();
            result.three.Should().BeTrue();
        }

        [Fact]
        public void aabcdd_has_1_two_and_0_three()
        {
            var result = IdStats.CountForChecksum("aabcdd");
            result.two.Should().BeTrue();
            result.three.Should().BeFalse();
        }

        [Fact]
        public void abcdee_has_1_two_and_0_three()
        {
            var result = IdStats.CountForChecksum("abcdee");
            result.two.Should().BeTrue();
            result.three.Should().BeFalse();
        }

        [Fact]
        public void ababab_has_0_two_and_1_three()
        {
            var result = IdStats.CountForChecksum("ababab");
            result.two.Should().BeFalse();
            result.three.Should().BeTrue();
        }

        [Fact]
        public void CreateChecksum()
        {
            int two = 0;
            int three = 0;

            foreach (var id in _ids)
            {
                var result = IdStats.CountForChecksum(id);
                if (result.two) two++;
                if (result.three) three++;
            }

            var checksum = two * three;
            checksum.Should().Be(6944);
        }
    }


    public static class IdStats
    {
        public static (bool two, bool three) CountForChecksum(string text)
        {
            var stats = new Dictionary<char, int>();
            foreach (var c in text)
            {
                if (stats.ContainsKey(c))
                {
                    stats[c]++;
                }
                else
                {
                    stats[c] = 1;
                }
            }

            var hasTwoChars = stats.Values.Any(v => v == 2);
            var hasThreeChars = stats.Values.Any(v => v == 3);
            return (hasTwoChars, hasThreeChars);
        }
    }
}
