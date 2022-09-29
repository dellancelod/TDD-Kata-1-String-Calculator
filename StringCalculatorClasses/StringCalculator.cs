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
            char delimiter = ',';

            if (numbers.Length == 0)
            {
                return 0;
            }

            if (numbers.StartsWith("//"))
            {
                delimiter = numbers[2];
                numbers = numbers.Remove(0, 4);
                Console.WriteLine(numbers);
            }

            Regex regex = new Regex(delimiter + @"|\n");
            List<int> additions = regex.Split(numbers).
                Select(Int32.Parse).ToList<int>();
            
            foreach (int number in additions)
            {
                if (number < 0) {
                    throw new NegativeNumberException("negatives not allowed");
                }
                summResult += number;
            }

            return summResult;
        }
    }
}
