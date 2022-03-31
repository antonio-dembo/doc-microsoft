using System;
using System.Xml;

namespace MappingObjectHierachyToXMLData
{
    public class Program
    {
        private const string filename = "items.xml";

        static void Main(string[] args)
        {
            XmlTextReader reader = null;

            try
            {
                reader = new XmlTextReader(filename)
                {
                    WhitespaceHandling = WhitespaceHandling.None
                };

                while (reader.Read())
                {
                    ParseFileAndDisplayEachOfTheNodes(reader);
                }
            }
            finally
            {
                if( reader != null)
                {
                    reader.Close();
                }
            }                        
        }

        private static void ParseFileAndDisplayEachOfTheNodes(XmlTextReader reader)
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Element:
                    Console.WriteLine("<{0}>", reader.Name);
                    break;
                case XmlNodeType.Text:
                    Console.WriteLine(reader.Value);
                    break;
                case XmlNodeType.CDATA:
                    Console.WriteLine("<![CDATA[{0}]]>", reader.Value);
                    break;
                case XmlNodeType.ProcessingInstruction:
                    Console.WriteLine("<?{0} {1}?>", reader.Name, reader.Value);
                    break;
                case XmlNodeType.Comment:
                    Console.Write("<!--{0}-->", reader.Value);
                    break;
                case XmlNodeType.XmlDeclaration:
                    Console.Write("<?xml version='1.0'?>");
                    break;
                case XmlNodeType.Document:
                    break;
                case XmlNodeType.DocumentType:
                    Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                    break;
                case XmlNodeType.EntityReference:
                    Console.Write(reader.Name);
                    break;
                case XmlNodeType.EndElement:
                    Console.Write("</{0}>", reader.Name);
                    break;
            }
        }
    }
}
