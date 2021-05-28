﻿using System;
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

            var delimiters = new List<char> { '\n', ',', '/', '[', ']',';' };

            var listNumbers = numbers;

            if (numbers.StartsWith("//"))
            {
                var splitInput = listNumbers.Split('\n');
                var newDelimiter = splitInput.First().Trim(delimiters.ToArray());
                var newNumbers = splitInput.Last().Replace(newDelimiter, ";");
                listNumbers = newNumbers;
                //delimiters.Add(Convert.ToChar(newDelimiter));

            }

            


            var numberList = listNumbers.Split(delimiters.ToArray())
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
