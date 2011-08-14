using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private static readonly List<string> _delimiters = new List<string> { ",", '\n'.ToString() };

        public static int Add(string numbers)
        {
            if (HasCustomDelimiter(numbers))
            {
                AddCustomDelimiter(numbers);
            }

            if (ContainsSeveralNumbers(numbers))
            {
                var allNumbers = numbers.Split(_delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(number => number.ToInt());

                var negativeNumbers = allNumbers.Where(number => number < 0);

                if (negativeNumbers.Any())
                    ThrowNegativeNumberException(negativeNumbers.Select(number => number.ToString()));

                return allNumbers
                    .Where(number => number < 1000)
                    .Sum(number => number);
            }

            return numbers.ToInt();
        }

        private static string ReplaceCustomDelimiterWithComma(string numbers)
        {
            string customDelimiter = FindCustomDelimiter(numbers);
            numbers = numbers.Replace(customDelimiter, ",");
            numbers = RemoveDelimiterPrefix(numbers);
            return numbers;
        }

        private static string FindCustomDelimiter(string numbers)
        {

            var delimiter = "";
            if (numbers.Contains("["))
            {
                var start = numbers.IndexOf("[") + 1;
                var stop = numbers.IndexOf("]");
                delimiter = numbers.Substring(start, stop - start);
            }
            else
            {
                delimiter = numbers.Substring(numbers.IndexOf("//") + 2, 1);
            }
            return delimiter;
        }

        private static bool HasCustomDelimiter(string numbers)
        {
            return numbers.Contains("//");
        }

        private static void AddCustomDelimiter(string numbers)
        {
            if (numbers.Contains("["))
            {
                var remaining = numbers;
                while (remaining.Contains("["))
                {
                    var start = remaining.IndexOf("[") + 1;
                    var stop = remaining.IndexOf("]");
                    var length = stop - start;

                    _delimiters.Add(remaining.Substring(start, length));

                    remaining = remaining.Substring(stop + 1);
                }
            }
            else
            {
                _delimiters.Add(numbers.Substring(numbers.IndexOf("//") + 2, 1));

            }
        }

        private static string RemoveDelimiterPrefix(string numbers)
        {
            return numbers.Substring(numbers.IndexOf("\n") + 1);
        }

        private static bool ContainsSeveralNumbers(string numbers)
        {
            return _delimiters.Any(x => numbers.Contains(x));
        }

        private static void ThrowNegativeNumberException(IEnumerable<string> negativeNumbers)
        {
            var message = negativeNumbers.Aggregate((current, negativeNumber) => current + ("," + negativeNumber));
            throw new Exception("Negative numbers not allowed: " + message);
        }
    }
}