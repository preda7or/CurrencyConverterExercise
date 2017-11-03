using Newtonsoft.Json;

namespace CurrencyConverterExercise.Models
{
    public class CurrenciesJsonModel
    {
        public string[] data;

        public CurrenciesJsonModel(string[] _data)
        {
            this.data = _data;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this.data, Newtonsoft.Json.Formatting.Indented);
        }
    }
}