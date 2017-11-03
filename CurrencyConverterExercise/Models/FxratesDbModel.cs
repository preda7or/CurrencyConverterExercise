using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverterExercise.Models
{
    using Currency = System.String;
    using Date = System.DateTime;
    using Fxrate = System.Single;

    public class FxratesDbModel
    {
        public struct FxratesRecord
        {
            public Currency currency;
            public Date date;
            public Fxrate rate;
            public FxratesRecord(Currency _currency, Date _date, Fxrate _fxrate)
            {
                this.currency = _currency;
                this.date = _date;
                this.rate = _fxrate;
            }
        }

        public Currency[] currencies;
        public Date[] dates;
        public Date currentDate;
        public Dictionary<Currency, Fxrate> currentFxrates;
        public FxratesRecord[] records;

        public FxratesDbModel(FxratesXmlModel xml)
        {
            var flat = xml.outerCube.dateCubes.SelectMany(
                dc => dc.rateCubes.Select(
                    rc => new FxratesRecord(rc.currency, dc.date, rc.rate)
                )
            ).OrderBy(o => o.date);

            this.currencies = flat.Select(f => f.currency).Distinct().ToArray();
            this.dates = flat.Select(f => f.date).Distinct().OrderByDescending(o => o.Date).ToArray();
            this.currentDate = this.dates[0];
            this.currentFxrates = flat.Where(f => f.date == currentDate).ToDictionary(d => d.currency, d => d.rate);
            this.records = flat.ToArray();
        }
    }
}
