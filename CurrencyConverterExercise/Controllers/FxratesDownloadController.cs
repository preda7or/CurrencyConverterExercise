using System;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CurrencyConverterExercise.Models
{
    public class FxratesDownloadController
    {
        const string url = "http://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml";

        public static string GetString()
        {
            string result;
            using (var web = new WebClient())
            {
                result = web.DownloadString(url);
            }
            return result;
        }

        public static FxratesDbModel GetModel()
        {
            FxratesXmlModel result;
            using (var web = new WebClient())
            using (var stream = web.OpenRead(url))
            using (var reader = XmlReader.Create(stream))
            {
                var serializer = new XmlSerializer(typeof(FxratesXmlModel));
                result = (FxratesXmlModel)serializer.Deserialize(reader);
            }
            return new FxratesDbModel(result);
        }
    }
}
