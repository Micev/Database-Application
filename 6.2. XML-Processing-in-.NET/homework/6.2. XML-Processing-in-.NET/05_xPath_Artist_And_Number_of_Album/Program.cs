using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _05_xPath_Artist_And_Number_of_Album
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new XmlDocument();
            doc.Load(@"..\..\..\catalog.xml");

            string artistXPath = "/albums/album/artist";

            var artistAlbums = new Dictionary<string, int>();

            XmlNodeList artistList = doc.SelectNodes(artistXPath);

            foreach (XmlNode artist in artistList)
            {
                string currentArtist = artist.InnerText;

                string albumsForArtistQuery =
                   "/albums/album[artist = \"" + currentArtist + "\" ]";
                int counter = 1;

                if (!artistAlbums.ContainsKey(currentArtist))
                {
                    artistAlbums.Add(currentArtist, counter);

                }
                else
                {
                    artistAlbums[currentArtist] = ++counter;
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
