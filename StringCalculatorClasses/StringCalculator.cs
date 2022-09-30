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
            List<string> delimeters = new List<string>();
            delimeters.Add("\n");

            if (numbers.Length == 0)
            {
                return 0;
            }

            //Check for delimiter
            if (numbers.StartsWith("//"))
            {
                if (numbers[2] == '[')
                {
                    Regex regexDelimiterPattern = new Regex(@"\[.*]");

                    MatchCollection matchedDelimeters = regexDelimiterPattern.Matches(numbers);

                    foreach (Match match in matchedDelimeters)
                    {
                        delimeters.Add(Regex.Replace(match.Value, @"\[?\.*\]?", ""));
                    }
                }
                else
                {
                    delimeters.Add(numbers[2].ToString());
                }

                //Remove delimiter command including new line symbol
                numbers = Regex.Replace(numbers, @".*\n", "");
            }

            for (int i = 0; i < delimeters.Count; i++)
            {
                Console.WriteLine(delimeters[i]);
                numbers = numbers.Replace(delimeters[i], ",");
            }

            List<int> additions = numbers.Split(',').
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
