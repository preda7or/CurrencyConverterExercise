using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CurrencyConverterExercise.Models
{
    using Fxrate = System.Single;
    using Currency = System.String;

    [XmlRoot(ElementName = "Envelope", Namespace = "http://www.gesmes.org/xml/2002-08-01")]
    public class FxratesXmlModel
    {
        [XmlRoot(ElementName = "Sender", Namespace = "http://www.gesmes.org/xml/2002-08-01")]
        public class Sender
        {
            [XmlElement(ElementName = "name", Namespace = "http://www.gesmes.org/xml/2002-08-01")]
            public string name { get; set; }
        }

        [XmlRoot(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
        public class RateCube
        {
            [XmlAttribute(AttributeName = "currency")]
            public Currency currency { get; set; }
            [XmlAttribute(AttributeName = "rate")]
            public Fxrate rate { get; set; }
        }

        [XmlRoot(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
        public class DateCube
        {
            [XmlElement(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
            public List<RateCube> rateCubes { get; set; }
            [XmlAttribute(AttributeName = "time")]
            //public string date { get { return _date.ToString("yyyy-MM-dd"); } set { _date = DateTime.Parse(value); } }
            //private DateTime _date;
            public DateTime date;
        }

        [XmlRoot(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
        public class OuterCube
        {
            [XmlElement(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
            public List<DateCube> dateCubes { get; set; }
        }

        [XmlElement(ElementName = "subject", Namespace = "http://www.gesmes.org/xml/2002-08-01")]
        public string subject { get; set; }
        [XmlElement(ElementName = "Sender", Namespace = "http://www.gesmes.org/xml/2002-08-01")]
        public Sender sender { get; set; }
        [XmlElement(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
        public OuterCube outerCube { get; set; }
        [XmlAttribute(AttributeName = "gesmes", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string gesmes { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string xmlns { get; set; }
    }

}
