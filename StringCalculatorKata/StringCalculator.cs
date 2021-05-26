using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        internal object Add(string number)
        {
            if (string.IsNullOrEmpty(number)) return 0;
            return int.Parse(number);
        }
    }
}
