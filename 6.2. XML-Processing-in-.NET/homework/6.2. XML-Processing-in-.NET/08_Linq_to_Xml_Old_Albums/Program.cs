



namespace _08_Linq_to_Xml_Old_Albums
{
    using System;
    using System.Xml.Linq;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            var doc = XDocument.Load(@"..\..\..\catalog.xml");

            var albums =
                from album in doc.Descendants("album")
                where Decimal.Parse(album.Element("year").Value) <= DateTime.Now.Year - 5
                select new
                {
                    Title = album.Element("name").Value,
                    Price = album.Element("price").Value
                };

            foreach (var album in albums)
            {
                Console.WriteLine(album);
            }


        }
    }
}
