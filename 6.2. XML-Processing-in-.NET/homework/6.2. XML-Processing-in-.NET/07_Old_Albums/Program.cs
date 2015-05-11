

namespace _07_Old_Albums
{
    using System;

    using System.Xml;
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new XmlDocument();
            doc.Load(@"..\..\..\catalog.xml");

            int year = DateTime.Now.Year - 5;

            string yearXPath = "/albums/album[year <= " + year + "]";

            XmlNodeList albumList = doc.SelectNodes(yearXPath);

            foreach (XmlNode album in albumList)
            {
                Console.WriteLine("Title: " + album["name"].InnerText);
                Console.WriteLine("Price: " + album["price"].InnerText);
                Console.WriteLine();
            }

        }
    }
}
