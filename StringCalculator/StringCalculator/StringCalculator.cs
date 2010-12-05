namespace StringCalculator
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers.Contains(",") || numbers.Contains("\n"))
            {
                var allNumbers = numbers.Split(new[] { ',', '\n' });
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