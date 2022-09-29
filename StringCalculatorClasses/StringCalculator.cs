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
            switch (numbers.Length)
            {
                case 0:
                    summResult = 0;
                    break;
                case 1:
                    if (Int32.TryParse(numbers, out summResult))
                    {
                    }
                    else
                    {
                        throw new FormatException();
                    }
                    break;
                case 3:
                    List<int> additions = numbers.Split(',').
                        Select(Int32.Parse).ToList<int>();
                    summResult = additions.Sum();
                    break;
                default:
                    throw new ArgumentException("Invalid input!");
            }
            return summResult;
        }
    }
}
