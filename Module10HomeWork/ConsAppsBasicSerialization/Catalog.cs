using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ConsAppsBasicSerialization
{
    [XmlRoot("catalog", Namespace = @"http://library.by/catalog")]
    public class Catalog
    {
        private DateTime creatTime;

        [XmlAttribute("date")]
        public string CreationTime
        {
            get { return creatTime.ToString("yyyy-MM-dd"); }
            set { creatTime = DateTime.Parse(value); }
        }

        [XmlElement("book")]
        public List<Book> CatalogList { get; set; }
    }
}
