using System;
namespace CurrencyConverterExercise.Models
{
    public class CalculationResultJsonModel
    {
        public readonly double fromAmount;
        public readonly string fromCurrency;
        public readonly double toAmount;
        public readonly string toCurrency;

        public CalculationResultJsonModel(double _fromAmount, string _fromCurrency, 
                                          double _toAmount, string _toCurrency)
        {
            this.fromAmount = _fromAmount;
            this.fromCurrency = _fromCurrency;
            this.toAmount = _toAmount;
            this.toCurrency = _toCurrency;
        }
    }
}
