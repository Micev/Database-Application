

using System.Globalization;

namespace _06_Delete_Album_With_Price
{
    using System;
    using System.Xml;


    class Program
    {
        static void Main()
        {
            System.Globalization.CultureInfo culInfo = new System.Globalization.CultureInfo("en-Au");

            var doc = new XmlDocument();
            doc.Load(@"..\..\..\catalog.xml");

            XmlNode albumsNode = doc.DocumentElement;

            for (int i = albumsNode.ChildNodes.Count - 1; i >= 0; i--)
            {
                if (decimal.Parse(albumsNode.ChildNodes[i]["price"].InnerText, culInfo) < 20)
                {
                    albumsNode.ChildNodes[i].ParentNode.RemoveChild(albumsNode.ChildNodes[i]);
                }
            }

            //пробвах и така но ми излиза от цикъла след първия romove

            //foreach (XmlNode album in albumsNode.ChildNodes)
            //{

            //    if (decimal.Parse(album["price"].InnerText, culInfo) < 20)
            //    {
            //albumNode.ParentNode.RemoveChild(albumNode);
            //    }
            //}

            doc.Save(@"../../../cheap-albums-catalog.xml");
            Console.WriteLine("Document has been saved.");

        }
    }
}
