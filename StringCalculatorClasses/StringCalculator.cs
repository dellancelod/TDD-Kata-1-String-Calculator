using System;
using System.Collections.Generic;
using System.Linq;

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

            List<int> additions = numbers.Split(',').Select(Int32.Parse).ToList<int>();
            summResult = additions.Sum();

            return summResult;
        }
    }
}
