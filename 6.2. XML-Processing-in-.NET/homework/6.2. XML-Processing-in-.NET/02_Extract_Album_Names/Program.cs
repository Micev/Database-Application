using System;
using System.Xml;

namespace _02_Extract_Album_Names
{
    class Program
    {
        static void Main()
        {
            var doc = new XmlDocument();
            doc.Load(@"..\..\..\catalog.xml");

            XmlNode albumsNode = doc.DocumentElement;

            foreach (XmlNode album in albumsNode.ChildNodes)
            {
                Console.WriteLine("Album name: " + album["name"].InnerText);
            }
        }
    }
}
