using System;
using System.Xml.Serialization;
using System.IO;

namespace ConsAppsBasicSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            string inFileXml = "..//..//books.xml";
            string outFileXml = "..//..//serializationBooks.xml";

            Catalog catalog;
            XmlSerializer objXMLSerializer = new XmlSerializer(typeof(Catalog));

            using (FileStream fileStream = new FileStream(inFileXml, FileMode.Open))
            {
                catalog = objXMLSerializer.Deserialize(fileStream) as Catalog;
            }

            using (FileStream fileStream = new FileStream(outFileXml, FileMode.Create))
            {
                objXMLSerializer.Serialize(fileStream, catalog);
            }

        }
    }
}
