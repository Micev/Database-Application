using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _10_XElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var xDocument = new XDocument(
                new XElement("root-dir", new XAttribute("path", "C:\\Example"),
                    new XElement("dir", new XAttribute("name", "docs"),
                        new XElement("file", new XAttribute("name", "tutorial.pdf")),
                        new XElement("file", new XAttribute("name", "TODO.txt")),
                        new XElement("file", new XAttribute("name", "Presentation.pptx"))),
                    new XElement("dir", new XAttribute("name", "photos"),
                        new XElement("dir", new XAttribute("name", "birthday-4-march"),
                            new XElement("file", new XAttribute("name", "friends.jpg")),
                            new XElement("file", new XAttribute("name", "the_cake.jpg")),
                            new XElement("file", new XAttribute("name", "balooooooooooooooooons.jpg")))),
                    new XElement("dir", new XAttribute("name", "travel"),
                        new XElement("file", new XAttribute("name", "IMG24152.jpg")))
                )               
            );

            xDocument.Save(@"..\..\..\xDocumnet.xml");
            Console.WriteLine("Document was created");

            
        }
    }
}
