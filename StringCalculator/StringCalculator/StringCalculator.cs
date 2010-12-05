namespace StringCalculator
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers.Contains(","))
            {
                var allNumbers = numbers.Split(',');
                return allNumbers[0].ToInt() + allNumbers[1].ToInt();
            }

            return numbers.ToInt();
        }
    }
}