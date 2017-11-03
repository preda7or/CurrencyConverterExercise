using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CurrencyConverterExercise.Models
{
    public class ModelConverter
    {
        public static CurrenciesJsonModel ConvertToCurrenciesJson(FxratesDbModel db)
        {
            //var flat = xml.outerCube.dateCubes[0].rateCubes.Select(rc => rc.currency).ToArray();
            return new CurrenciesJsonModel(db.currencies);
        }

        public static HistoryJsonModel ConvertToHistoryJson(FxratesDbModel db)
        {

            //var flat = xml.outerCube.dateCubes.SelectMany(dc => dc.rateCubes.Select(rc => new { rc.currency, dc.date, rc.rate })).OrderBy(o => o.date);
            //var temp = flat.GroupBy(f => f.currency, (key, grp) => new HistoryJsonModel.DataSeries { name = key, data = grp.Select(r => new HistoryJsonModel.DataPoint(r.date, r.rate)).ToArray() }).ToArray();
            var result = db.records.GroupBy(f => f.currency, (key, grp) => new HistoryJsonModel.DataSeries { name = key, data = grp.Select(r => new HistoryJsonModel.DataPoint(r.date, r.rate)).ToArray() }).ToArray();
            return new HistoryJsonModel(result);
        }
    }
}
