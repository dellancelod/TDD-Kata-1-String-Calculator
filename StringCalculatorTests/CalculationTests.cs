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
        public void Add_sum5numbers_18()
        {
            int result = _stringCalculator.Add("1,2,3,5,7");
            Assert.AreEqual(18, result);
        }
        [Test]
        public void Add_sum1char_FormatException()
        {
            Assert.That(() => _stringCalculator.Add("&"), Throws.TypeOf<FormatException>());
        }
        [Test]
        public void Add_sumOfChars_FormatException()
        {
            Assert.That(() => _stringCalculator.Add("&,#,a"), Throws.TypeOf<FormatException>());
        }
        [Test]
        public void Add_coma_FormatException()
        {
            Assert.That(() => _stringCalculator.Add(","), Throws.TypeOf<FormatException>());
        }
        [Test]
        public void Add_newLineSymbolInsteadOfComa_18()
        {
            int result = _stringCalculator.Add("1,2\n3\n5,7");
            Assert.AreEqual(18, result);
        }
        [Test]
        public void Add_newLineAndComaSymbols_FormatException()
        {
            Assert.That(() => _stringCalculator.Add("1,2,\n3\n5,7"), Throws.TypeOf<FormatException>());
        }

    }
}