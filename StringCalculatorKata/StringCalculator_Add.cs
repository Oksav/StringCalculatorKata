using System;
using Xunit;

namespace StringCalculatorKata
{

    public class StringCalculator_Add
    {
        [Fact]
        public void Returns0GivenEmptyString()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("");

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1.2", 1)]
        [InlineData("2",2)]
        public void ReturnsNumberGivenStringWithNumbers(string number, int expectedResult)
        {
            var calculator = new StringCalculator();

            var result = calculator.Add(number);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        public void ReturnsSumGivenStringWithTwoCommaSeparatedNumbers(string number, int expectedResult)
        {
            var calculator = new StringCalculator();

            var result = calculator.Add(number);

            Assert.Equal(expectedResult, result);
        }
    }
}
