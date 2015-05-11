using System;
using System.Collections.Generic;
using System.Xml;

namespace _03_All_Artists
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new XmlDocument();
            doc.Load(@"..\..\..\catalog.xml");

            XmlNode albumsNode = doc.DocumentElement;

            var artists = new SortedSet<string>();
            //add all artist name from xml file to SortedSet file.
            foreach (XmlNode album in albumsNode.ChildNodes)
            {
                artists.Add(album["artist"].InnerText);
            }

            foreach (var artist in artists)
            {
                Console.WriteLine(artist);
            }
            
        }
    }
}
