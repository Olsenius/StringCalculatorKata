namespace StringCalculator
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers.Contains(","))
            {
                var allNumbers = numbers.Split(',');
                int sum = 0;
                foreach (var number in allNumbers)
                {
                    sum += number.ToInt();
                }
                return sum;
            }

            return numbers.ToInt();
        }
    }
}