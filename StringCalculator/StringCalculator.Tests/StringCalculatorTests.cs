using System.Linq;
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

        [TestCase("1", 1)]
        [TestCase("37", 37)]
        public void Should_handle_single_numbers(string numbers, int expectedSum)
        {
            var result = StringCalculator.Add(numbers);
            result.ShouldEqual(expectedSum);
        }

        [TestCase("1,2", 3)]
        public void Should_handle_two_numbers(string numbers, int expectedSum)
        {
            var result = StringCalculator.Add(numbers);
            result.ShouldEqual(expectedSum);
        }
    }
}