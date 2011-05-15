using System;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers.Contains("-"))
                throw new Exception();
            char delimiter = 'a';

            if (numbers.Contains("//"))
            {
                delimiter = Convert.ToChar(numbers.Substring(numbers.IndexOf("//") + 2, 1));
                numbers = numbers.Substring(numbers.IndexOf("//") + 4);
            }

            if (numbers.Contains(",") || numbers.Contains("\n") || numbers.Contains(delimiter))
            {
                var allNumbers = numbers.Split(new[] { ',', '\n', delimiter });
                return allNumbers.Sum(number => number.ToInt());
            }

            return numbers.ToInt();
        }
    }
}