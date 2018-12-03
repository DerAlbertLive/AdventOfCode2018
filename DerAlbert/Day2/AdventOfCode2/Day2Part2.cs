using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2
{
    [Collection("InputData")]
    public class Day2Part2
    {
        private string[] _ids;

        public Day2Part2(InputFixture fixture)
        {
            _ids = fixture.Identifiers;
        }

        [Fact]
        public void SubDiffString()
        {
            var a = "fghij";
            var b = "fguij";

            var result = GetCommonChars(a, b);

            result.Should().Be("fgij");
        }

        [Theory]
        [InlineData("fghij", "fguij", "fgij")]
        [InlineData("fghij", "fghij", null)]
        [InlineData("abcde", "axcye", null)]
        public void SubDiffString2(string a, string b, string expected)
        {
            var result = GetCommonChars(a, b);
            result.Should().Be(expected, $"{a} ~ {b} = {expected}");
        }

        [Fact]
        public void FindIt()
        {
            var commons = new List<string>();
            foreach (var current in _ids)
            {
                foreach (var compare in _ids)
                {
                    var common = GetCommonChars(current, compare);
                    if (common != null)
                    {
                        if (!commons.Contains(common))
                        {
                            commons.Add(common);
                        }
                    }
                }
            }

            commons.Count.Should().Be(1);
            commons[0].Should().Be("srijafjzloguvlntqmphenbkd");
        }

        private string GetCommonChars(string a, string b)
        {
            var originalLength = a.Length;

            if (a.Length != b.Length)
            {
                return null;
            }

            var commonChars = new List<char>();
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] == b[i])
                {
                    commonChars.Add(a[i]);
                }
            }

            var result = new string(commonChars.ToArray());

            if (result.Length == originalLength - 1)
            {
                return result;
            }

            return null;
        }
    }
}