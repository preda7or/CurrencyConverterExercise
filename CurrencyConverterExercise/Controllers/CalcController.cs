using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using CurrencyConverterExercise.Models;

namespace CurrencyConverterExercise.Controllers
{
    /// <summary>
    /// Fx rates API controller
    /// </summary>


    public class CalcController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(CalculationResultJsonModel))]
        public IHttpActionResult GetWarning()
        {
            return Ok($"<pre>Use /api/calc/<fromCurrency>/<toCurrency>/<amount> instead (e.g. /api/calc/USD/JPY/2)</pre>");
        }

        [HttpGet]
        [Route("api/calc/{cFrom}/{cTo}")]
        public IHttpActionResult GetCalculationResult(string cFrom, string cTo) {
            return GetCalculationResult(cFrom, cTo, 1);
        }


        [HttpGet]
        [Route("api/calc/{cFrom}/{cTo}/{amount}")]
        public IHttpActionResult GetCalculationResult(string cFrom, string cTo, double amount)
        {
            var db = FxratesDownloadController.GetModel();
            var calc = new CalculationModel(db);
            var val = calc.Calculate(cFrom, cTo, amount);
            var result = new CalculationResultJsonModel(amount,cFrom,val, cTo);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/currencies")]
        public IHttpActionResult GetAvailableCurrencies()
        {
            var db = FxratesDownloadController.GetModel();
            var json = ModelConverter.ConvertToCurrenciesJson(db);
            return Ok(json.data);
        }
    }
}
