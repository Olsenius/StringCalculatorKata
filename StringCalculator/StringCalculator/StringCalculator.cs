using System;

namespace StringCalculator
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) 
                return 0;
            return Convert.ToInt32(numbers);
        }
    }
}