using FileReadingLibrary.Exceptions;
using System;
using System.IO;
using System.Xml.Linq;

namespace FileReadingLibrary
{
    public class XmlFileReader : FileReader
    {
        public override string ReadFile(string filepath)
        {
            if (IsValidTextFile(filepath))
            {
                XDocument xmlDocument = XDocument.Load(filepath);
                return xmlDocument.ToString();
            }
            else
            {
                throw new InvalidFileTypeException(filepath, "*.xml");
            }
        }

        private bool IsValidTextFile(string filepath)
        {
            return Path.GetExtension(filepath).Equals(".xml", StringComparison.OrdinalIgnoreCase);
        }
    }
}
