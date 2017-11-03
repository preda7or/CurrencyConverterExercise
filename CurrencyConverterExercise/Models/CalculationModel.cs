using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverterExercise.Models
{
    using Fxrate = System.Single;
    using CurrencyPair = Tuple<string, string>;

    public class CalculationModel
    {
        private Dictionary<CurrencyPair, double> rates = new Dictionary<CurrencyPair, double>();

        public CalculationModel(FxratesDbModel db)
        {
            float rateFrom;
            float rateTo;
            foreach (var currencyFrom in db.currencies)
            {
                if(!db.currentFxrates.TryGetValue(currencyFrom, out rateFrom)) {
                    throw new Exception("Currency error while preprocessing!");
                }
                foreach (var currencyTo in db.currencies)
                {
                    if (!db.currentFxrates.TryGetValue(currencyTo, out rateTo))
                    {
                        throw new Exception("Currency error while preprocessing!");
                    }
                    rates.Add(new CurrencyPair(currencyFrom,currencyTo),rateTo/rateFrom);
                }
            }
        }

        public double Calculate(string cFrom, string cTo, double amount) {
            double rate;
            if (!rates.TryGetValue(new CurrencyPair(cFrom,cTo), out rate))
            {
                throw new Exception("There is no exchange rate for the  selected currency combination!");
            }
            return amount * rate;
        }
    }
}
