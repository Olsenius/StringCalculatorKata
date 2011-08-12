using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private static readonly List<char> _delimiters = new List<char> { ',', '\n' };

        public static int Add(string numbers)
        {
            if (numbers.Contains("-"))
                throw new Exception("-1");

            if (HasCustomDelimiter(numbers))
            {
                AddCustomDelimiter(numbers);
                numbers = RemoveDelimiterPrefix(numbers);
            }

            if (ContainsSeveralNumbers(numbers))
            {
                var allNumbers = numbers.Split(_delimiters.ToArray());
                return allNumbers.Sum(number => number.ToInt());
            }

            return numbers.ToInt();
        }

        private static bool HasCustomDelimiter(string numbers)
        {
            return numbers.Contains("//");
        }

        private static void AddCustomDelimiter(string numbers)
        {
            _delimiters.Add(Convert.ToChar(numbers.Substring(numbers.IndexOf("//") + 2, 1)));
        }

        private static string RemoveDelimiterPrefix(string numbers)
        {
            return numbers.Substring(numbers.IndexOf("//") + 4);
        }

        private static bool ContainsSeveralNumbers(string numbers)
        {
            return _delimiters.Any(x => numbers.Contains(x));
        }
    }
}