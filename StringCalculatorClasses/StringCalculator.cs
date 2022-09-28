using System;

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
            }
            return summResult;
        }
    }
}
