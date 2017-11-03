using NUnit.Framework;
using System.Web.Mvc;
using System.Web.Routing;
using MvcRouteTester;

namespace CurrencyConverterExercise.Tests.Routing
{
    [TestFixture]
    public class RouteTest
    {
        private RouteCollection routes;

        [SetUp]
        public void MakeRouteTable()
        {
            routes = new RouteCollection();

            routes.MapRoute(
                name: "CalculationApi",
                url: "api/calculation/{cFrom}/{cTo}/{amount}",
                defaults: new { amount = UrlParameter.Optional, controller = "Calculation" }
            );

            routes.MapRoute(
                name: "DefaultApi",
                url: "api/{controller}/{action}",
                defaults: new { action = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void CheckRouteCurrencies()
        {
            RouteAssert.HasRoute(routes, "/api/calculation/currencies");
        }
        [Test]
        public void CheckRouteCalculationWithoutAmount()
        {
            RouteAssert.HasRoute(routes, "/api/calculation/ABC/ABC");
            //RouteAssert.NoRoute(routes, "/api/calculation/ABC/");
            //RouteAssert.NoRoute(routes, "/api/calculation/ABC/ABCD");
            //RouteAssert.NoRoute(routes, "/api/calculation/ABCD");
        }
        [Test]
        public void CheckRouteCalculation()
        {
            RouteAssert.HasRoute(routes, "/api/calculation/USD/JPY/1");
        }
        [Test]
        public void CheckRouteFxrates()
        {
            RouteAssert.HasRoute(routes, "/api/fxrates");
        }
    }
}
