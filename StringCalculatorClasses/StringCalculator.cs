using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculatorClasses
{
    public class StringCalculator
    {
        static private int addInvokeCount;
        public event Action<string, int> AddOccured;
        public StringCalculator()
        {
            addInvokeCount = 0;
        }
        public int Add(string numbers)
        {
            addInvokeCount += 1;
            AddOccured?.Invoke(numbers, addInvokeCount);

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
            }

            Regex regex = new Regex(delimiter + @"|\n");
            List<int> additions = regex.Split(numbers).
                Select(Int32.Parse).ToList<int>();

            List<int> negativeNumbers = new List<int>();
            foreach (int number in additions)
            {
                if (number < 0) {
                    negativeNumbers.Add(number);
                    continue;
                }
                if (number <= 1000)
                {
                    summResult += number;
                }
            }
            if (negativeNumbers.Count > 0)
            {
                throw new NegativeNumberException("negatives not allowed: " + String.Join(" ", negativeNumbers));
            }

            return summResult;
        }
        public int GetCalledCount()
        {
            return addInvokeCount;
        }
    }
}
