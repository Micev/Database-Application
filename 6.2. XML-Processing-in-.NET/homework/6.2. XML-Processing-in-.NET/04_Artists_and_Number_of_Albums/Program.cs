namespace _04_Artists_and_Number_of_Albums
{
    using System;
    using System.Xml;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var doc = new XmlDocument();
            doc.Load(@"..\..\..\catalog.xml");

            XmlNode albumsNode = doc.DocumentElement;

            var artistAlbums = new Dictionary<string, int>();

            foreach (XmlNode album in albumsNode)
            {
                int counter = 1;
                if (!artistAlbums.ContainsKey(album["artist"].InnerText))
                {
                    artistAlbums.Add(album["artist"].InnerText, counter);

                }
                else
                {
                    artistAlbums[album["artist"].InnerText] = ++counter;
                    counter += counter;
                }
            }

            foreach (var kvp in artistAlbums)
            {
                Console.WriteLine("Artist = {0}, Number of Albums = {1}",
                    kvp.Key, kvp.Value);
            }
        }
    }
}
