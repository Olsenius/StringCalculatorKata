using System;
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

        [TestCase("1,2,3,4", 10)]
        public void Should_handle_many_numbers(string numbers, int expectedSum)
        {
            var result = StringCalculator.Add(numbers);
            result.ShouldEqual(expectedSum);
        }

        [TestCase("1\n2,3", 6)]
        public void Should_handle_new_line_between_numbers(string numbers, int expectedSum)
        {
            var result = StringCalculator.Add(numbers);
            result.ShouldEqual(expectedSum);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//å\n1å2,3", 6)]
        public void Should_handle_different_delimiters(string numbers, int expectedSum)
        {
            var result = StringCalculator.Add(numbers);
            result.ShouldEqual(expectedSum);
        }

        [TestCase("1,-1")]
        [TestCase("1,-2")]
        public void Negative_number_should_throw_exception(string numbers)
        {
            var exception = GetExeption(StringCalculator.Add, numbers);
        }

        [TestCase("1,-1","-1")]
        [TestCase("1,-2","-2")]
        public void Negative_number_should_be_returned_as_message(string numbers,string expectedMessage)
        {
            var exception = GetExeption(StringCalculator.Add, numbers);

            exception.Message.ShouldContain(expectedMessage);
        }

        public static Exception GetExeption(Func<string, int> function, string parameter)
        {
            try
            {
                function(parameter);
            }
            catch (Exception e)
            {
                return e;
            }
            Assert.Fail("Did not throw exception.");
            return null;
        }   
    }
}