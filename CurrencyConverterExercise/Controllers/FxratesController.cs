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

    [RoutePrefix("api/[controller]")]
    public class FxratesController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(HistoryJsonModel))]
        public IHttpActionResult Get()
        {
            var fxratesModel = FxratesDownloadController.GetModel();
            var fxratesJson = ModelConverter.ConvertToHistoryJson(fxratesModel);
            return Ok(fxratesJson.data);
        }
    }
}
