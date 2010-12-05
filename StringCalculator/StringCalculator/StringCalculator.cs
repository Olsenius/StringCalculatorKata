using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers.Contains(",") || numbers.Contains("\n"))
            {
                var allNumbers = numbers.Split(new[] { ',', '\n' });
                return allNumbers.Sum(number => number.ToInt());
            }

            return numbers.ToInt();
        }
    }
}