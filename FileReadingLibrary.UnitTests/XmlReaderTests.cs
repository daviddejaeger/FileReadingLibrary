using FileReadingLibrary.Exceptions;
using System;
using System.IO;
using System.Xml;
using Xunit;

namespace FileReadingLibrary.UnitTests
{
    public class XmlReaderTests
    {
        FileReader xmlFileReader;

        public XmlReaderTests()
        {
            xmlFileReader = new XmlFileReader();
        }

        [Fact]
        public void ReadFile_CorrectPath_ReturnsFileContents()
        {
            string path = @"devices.xml";

            string contents = xmlFileReader.ReadFile(path);

            Assert.Equal("<?xml version=\"1.0\" encoding=\"utf - 8\" ?><Machines><Machine>PCGC04</Machine></Machines>", contents);
        }
        [Fact]
        public void ReadFile_CorrectPathIncorrectXml_ReturnsFormatException()
        {
            string path = @"devicesWrongFormat.xml";

            Action action = () => xmlFileReader.ReadFile(path);

            Assert.Throws<XmlException>(action);
        }

        [Fact]
        public void ReadFile_IncorrectPath_ReturnsFileNotFoundException()
        {
            string path = @"wrongfile.xml";

            Action action = () => xmlFileReader.ReadFile(path);

            Assert.Throws<FileNotFoundException>(action);
        }

        [Fact]
        public void ReadFile_IncorrectFileType_ReturnsInvalidFileTypeException()
        {
            string path = @"icon-72x72.png";

            Action action = () => xmlFileReader.ReadFile(path);

            Assert.Throws<InvalidFileTypeException>(action);
        }
    }
  
}
