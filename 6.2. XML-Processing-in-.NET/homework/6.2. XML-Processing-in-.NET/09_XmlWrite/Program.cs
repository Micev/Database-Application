namespace _09_XmlWrite
{
    using System;
    using System.Text;
    using System.Xml;
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = @"..\..\..\xmlWriter.xml";
            var encoding = Encoding.GetEncoding("utf-8");

            using (var writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();

                writer.WriteStartElement("root-dir");
                writer.WriteAttributeString("path","C:\\Example");

                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", "docs");
                WriteFailWithAttribute(writer, "tutorial.pdf");
                WriteFailWithAttribute(writer, "TODO.txt");
                WriteFailWithAttribute(writer, "Presentation.pptx");

                //close dir element
                writer.WriteEndElement();
                
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", "photos");
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", "birthday-4-march");
                WriteFailWithAttribute(writer, "friends.jpg");
                WriteFailWithAttribute(writer, "the_cake.jpg");
                WriteFailWithAttribute(writer, "baloons.jpg");

                //close dir element with name = birthday-4-march
                writer.WriteEndElement();

                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", "travel");
                WriteFailWithAttribute(writer, "IMG24152.jpg");

                //close dir element with name = travel
                writer.WriteEndElement();

                //close dir element with name = photos
                writer.WriteEndElement();

                //close root-dir element
                writer.WriteEndElement();
                
            }
            Console.WriteLine("Document was created.");
        }

        private static void WriteFailWithAttribute(XmlWriter writer,  string value)
        {
            writer.WriteStartElement("file");
            writer.WriteAttributeString("name", value);
            writer.WriteEndElement();
        }
    }
}
