using NUnit.Framework;
using StringCalculatorClasses;
using System;

namespace StringCalculatorTests
{
    public class CalculationTests
    {
        private StringCalculator _stringCalculator { get; set; } = null;
        [SetUp]
        public void Setup()
        {
            _stringCalculator = new StringCalculator();
        }

        [Test]
        public void Add_sum0numbers_0()
        {
            int result = _stringCalculator.Add("");
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_sum1numbers_1()
        {
            int result = _stringCalculator.Add("1");
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Add_sum2numbers_3()
        {
            int result = _stringCalculator.Add("1,2");
            Assert.AreEqual(3, result);
        }
        [Test]
        public void Add_sum3numbers_ArgumentException()
        {
            Assert.That(() => _stringCalculator.Add("1,2,3"), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void Add_sum1char_FormatException()
        {
            Assert.That(() => _stringCalculator.Add("&"), Throws.TypeOf<FormatException>());
        }
    }
}