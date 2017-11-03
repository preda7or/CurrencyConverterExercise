using NUnit.Framework;
using System;
using CurrencyConverterExercise.Models;
using CurrencyConverterExercise.Controllers;

namespace CurrencyConverterExercise.Tests.Controllers
{
    [TestFixture]
    public class FxratesDownloadControllerTest
    {
        [Test]
        public void ToStringTest()
        {
            string result = FxratesDownloadController.GetString();
            StringAssert.StartsWith("<?xml", result);
            Console.WriteLine(result);
        }
    }
}
