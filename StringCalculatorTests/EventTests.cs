using NUnit.Framework;
using StringCalculatorClasses;
using System;

namespace StringCalculatorTests
{

    public class EventTests
    {
        private StringCalculator _stringCalculator { get; set; } = null;
        [SetUp]
        public void Setup()
        {
            _stringCalculator = new StringCalculator();
        }
        [Test]
        public void AddOccured_eventIsFired()
        {
            var wasCalled = false;

            _stringCalculator.AddOccured += 
                (string input,
                int result) =>{wasCalled = true;};

            int result = _stringCalculator.Add("1,2");

            Assert.IsTrue(wasCalled);
        }
    }
}