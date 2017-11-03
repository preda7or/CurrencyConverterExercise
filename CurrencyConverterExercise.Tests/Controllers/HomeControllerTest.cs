﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CurrencyConverterExercise;
using CurrencyConverterExercise.Controllers;

namespace CurrencyConverterExercise.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = (ViewResult)controller.Index();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
