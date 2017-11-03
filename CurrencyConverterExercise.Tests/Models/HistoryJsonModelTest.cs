using NUnit.Framework;
using System;
using CurrencyConverterExercise.Models;
using Moq;

namespace CurrencyConverterExercise.Tests.Models
{
    [TestFixture]
    public class HistoryJsonModelTest
    {
        [Test]
        public void ToStringTest()
        {
            string result = new HistoryJsonModel().ToString();
            StringAssert.StartsWith("[", result);
            Console.WriteLine(result);
        }

    }
}
