using System;
using Xunit;

namespace ClassLibrary1.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(9, 18)]
        [InlineData(-5, -10)]
        public void DoubleTest_Simple1(int x, int expected)
        {
            var actual = new Class1().Double(x);

            Assert.Equal(expected, actual);
        }
    }
}
