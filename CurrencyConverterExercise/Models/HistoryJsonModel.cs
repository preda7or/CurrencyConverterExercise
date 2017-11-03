using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Collections;

namespace CurrencyConverterExercise.Models
{
    using Fxrate = System.Single;
    using Currency = System.String;

    public class HistoryJsonModel
    {
        private readonly DateTime _lastUpdated;
        public string lastUpdated { get; set; }

        public struct DataPoint
        {
            private static DateTime baseDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            public double x;
            public float y;
            public DataPoint(DateTime _x, Fxrate _y)
            {
                x = _x.ToUniversalTime().Subtract(baseDate).TotalSeconds;
                y = _y;
            }
        }

        public struct DataSeries
        {
            public Currency name;
            public DataPoint[] data;
        }

        //public HistoryJsonModel()
        //{

        //}

        public DataSeries[] data = new DataSeries[0];

        public HistoryJsonModel(DataSeries[] _data)
        {
            this.data = _data;
        }

        public HistoryJsonModel()
        {
            _lastUpdated = DateTime.Now;
        }

        public override Currency ToString()
        {
            return JsonConvert.SerializeObject(this.data, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
