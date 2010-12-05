using System;

namespace StringCalculator
{
    public static class StringExtensions
    {
        public static int ToInt(this string number)
        {
            try
            {
                return Convert.ToInt32(number);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}