using System;
using NUnit.Framework;
using StringCalculatorClasses;

namespace StringCalculatorTests
{
    class GetCalledTests
    {
        private StringCalculator _stringCalculator { get; set; } = null;
        [SetUp]
        public void Setup()
        {
            _stringCalculator = new StringCalculator();
        }

        [Test]
        public void GetCalledCount_countAddInvoke_3()
        {
            int result = _stringCalculator.Add("1,2");
            result = _stringCalculator.Add("1,2\n3\n5,7");
            result = _stringCalculator.Add("//;\n1;2;3;5;7");

            Assert.AreEqual(3, _stringCalculator.GetCalledCount());
        }

    }
}
