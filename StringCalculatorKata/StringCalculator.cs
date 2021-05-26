using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        internal object Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;
            
            var delimiters = new List<char> { '\n', ','};

            var newNumbers = numbers;

            if (numbers.StartsWith("//"))
            {
                var splitInput = numbers.Split('\n');
                var newDelimiter = splitInput.First().Trim('/');
                newNumbers = String.Join('\n', splitInput.Skip(1));

                delimiters.Add(Convert.ToChar(newDelimiter));
                      
            }

            var numberList = newNumbers.Split(delimiters.ToArray())
                .Select(s => int.Parse(s));

            var negatives = numberList.Where(x => x < 0);

            if (negatives.Any())
            {
                string negativeString = String.Join(',', negatives
                    .Select(n => n.ToString()));

                throw new Exception($"Negatives not allowed: {negativeString}");
            }
            
            var result = numberList.Where(n => n <= 1000).Sum();

            return result;
        }
    }
}
