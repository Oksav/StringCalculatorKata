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

            var delimiters = new char[] { '\n', ',' };
            var result = numbers.Split(delimiters)
                .Select(s => int.Parse(s)).Sum();

            return result;
        }
    }
}
