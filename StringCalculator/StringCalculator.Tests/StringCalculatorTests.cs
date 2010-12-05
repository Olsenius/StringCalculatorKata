using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Empty_string_should_be_0()
        {
            var result = StringCalculator.Add("");
            result.ShouldEqual(0);
        }

        [Test]
        public void Single_number_should_be_number()
        {
            var result = StringCalculator.Add("1");
            result.ShouldEqual(1);
        }
    }
}