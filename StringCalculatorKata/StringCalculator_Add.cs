using System;
using Xunit;

namespace StringCalculatorKata
{

    public class StringCalculator_Add
    {
        StringCalculator calculator = new StringCalculator();
        [Fact]
        public void Returns0GivenEmptyString()
        {
            var result = calculator.Add("");

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2",2)]
        public void ReturnsNumberGivenStringWithNumbers(string number, int expectedResult)
        {
            var result = calculator.Add(number);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("4,5", 9)]
        [InlineData("2,3,4,1", 10)]
        public void ReturnsSumGivenStringWithTwoCommaSeparatedNumbers(string number, int expectedResult)
        {
            var result = calculator.Add(number);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1\n2,3", 6)]
        [InlineData("1\n2\n3", 6)]
        [InlineData("1,2\n3", 6)]
        public void ReturnsSumGivenStringWithCommaOrNewLinesBetweenNumbers(string number, int expectedResult)
        {
            var result = calculator.Add(number);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("//;\n1;2;3", 6)]
        public void ReturnsSumGivenStringWithCustomDelimiter(string number, int expectedResult)
        {
            var result = calculator.Add(number);

            Assert.Equal(expectedResult, result);
        }
    }
}
