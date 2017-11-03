using System;
using CurrencyConverterExercise.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CurrencyConverterExercise.Tests.Models
{
    [TestFixture]
    public class ModelConversionTest
    {
        [Test]
        public void HistoryConversionTest()
        {
            var db = FxratesDownloadController.GetModel();
            var json = ModelConverter.ConvertToHistoryJson(db).ToString();
            StringAssert.StartsWith("[", json);
            StringAssert.Contains("USD", json);
            Console.WriteLine(json);
        }
        [Test]
        public void CurrenciesConversionTest()
        {
            var db = FxratesDownloadController.GetModel();
            var json = ModelConverter.ConvertToCurrenciesJson(db).ToString();
            StringAssert.StartsWith("[", json);
            StringAssert.DoesNotContain("{", json);
            StringAssert.Contains("USD", json);
            Console.WriteLine(json);
        }
        [Test]
        public void DatabaseConversionTest()
        {
            var db = FxratesDownloadController.GetModel();
            var json = JsonConvert.SerializeObject(db, Formatting.Indented);
            StringAssert.StartsWith("{", json);
            Assert.IsNotNull(db.currencies);
            Assert.IsNotNull(db.currentDate);
            Assert.IsNotNull(db.currentFxrates);
            Assert.IsNotNull(db.dates);
            Assert.IsNotNull(db.records);
            Console.WriteLine(json);
        }
    }
}
