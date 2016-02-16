using System;
using System.Xml.Serialization;

namespace ConsAppsBasicSerialization
{
    [XmlType("book")]
    public class Book
    {
        private DateTime pubDate;
        private DateTime regDate;

        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("isbn")]
        public string Isbn { get; set; }

        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("genre")]
        public Genre Genre { get; set; }

        [XmlElement("publisher")]
        public string Publisher { get; set; }

        [XmlElement("publish_date")]
        public string PublishDate
        {
            get { return pubDate.ToString("yyyy-MM-dd"); }
            set { pubDate = DateTime.Parse(value); }
        }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("registration_date")]
        public string RegistrationDate
        {
            get { return regDate.ToString("yyyy-MM-dd"); }
            set { regDate = DateTime.Parse(value); }
        }
    }

    public enum Genre
    {        
        [XmlEnum("Science Fiction")]
        ScienceFiction,

        [XmlEnum]
        Computer,

        [XmlEnum]
        Fantasy,

        [XmlEnum]
        Romance,

        [XmlEnum]
        Horror
    }
}
