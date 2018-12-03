using System.IO;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2
{
    public class InputFixture
    {
        private string[] _lines;

        public InputFixture()
        {
            _lines = File.ReadAllLines("input.txt");
        }

        public string[] Identifiers => _lines;
    }

    [CollectionDefinition("InputData", DisableParallelization = true)]
    public class InputFixtureCollection : ICollectionFixture<InputFixture>
    {

    }

    [Collection("InputData")]
    public class Test1
    {
        private string[] _ids;

        public Test1(InputFixture input)
        {
            _ids = input.Identifiers;
        }

        [Fact]
        public void CHeck()
        {
            _ids.Length.Should().Be(250);
        }
    }
}