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

        [Theory]
        [InlineData("-1,2", "Negatives not allowed: -1")]
        [InlineData("-1,-2", "Negatives not allowed: -1,-2")]
        public void ThrowsGivenNegativeInputs(string numbers, string expectedMessage)
        {

            Action action = () => calculator.Add(numbers);
            var ex = Assert.Throws<Exception>(action);

            Assert.Equal(expectedMessage, ex.Message);
        }

        [Theory]
        [InlineData("1001,2", 2)]
        [InlineData("3002,5", 5)]
        [InlineData("1000,9",1009)]
        public void ReturnsSumGivenStringWithoutNumberOver1000(string number, int expectedResult)
        {
            var result = calculator.Add(number);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("//[|||]\n1|||2|||3", 6)]
        public void ReturnsSumGivenStringWithMultipleDelimiters(string number, int expectedResult)
        {
            var result = calculator.Add(number);

            Assert.Equal(expectedResult, result);
        }
    }
}
