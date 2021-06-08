using System;
using System.IO;
using System.Xml.Linq;

namespace FileReadingLibrary
{
    public class XmlFileReader : FileReader
    {
        public override string ReadFile(string filepath)
        {
             XDocument xmlDocument = XDocument.Load(filepath);
            return xmlDocument.ToString();
        }
    }
}
