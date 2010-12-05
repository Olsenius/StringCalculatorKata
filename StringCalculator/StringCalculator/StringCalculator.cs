using System;

namespace StringCalculator
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) 
                return 0;
            if (numbers.Contains(","))
            {
                var allNumbers = numbers.Split(',');
                return Convert.ToInt32(allNumbers[0]) + Convert.ToInt32(allNumbers[1]);
            }

            return Convert.ToInt32(numbers);
        }
    }
}