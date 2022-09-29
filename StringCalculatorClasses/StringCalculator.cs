using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculatorClasses
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            int summResult = 0;

            if (numbers.Length == 0)
            {
                return 0;
            }

            Regex regex = new Regex(@",|\n");
            List<int> additions = regex.Split(numbers).
                Select(Int32.Parse).ToList<int>();
            summResult = additions.Sum();

            return summResult;
        }
    }
}
