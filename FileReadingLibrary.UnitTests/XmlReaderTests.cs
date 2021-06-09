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
            string path = @"testfiles/devices.xml";

            string contents = xmlFileReader.ReadFile(path);

            Assert.Equal("<Machines>\r\n  <Machine>PCGC04</Machine>\r\n</Machines>", contents);
        }
        [Fact]
        public void ReadFile_IncorrectXml_ReturnsXmlException()
        {
            string path = @"testfiles/devicesWrongFormat.xml";

            Action action = () => xmlFileReader.ReadFile(path);

            Assert.Throws<XmlException>(action);
        }

        [Fact]
        public void ReadFile_IncorrectPath_ReturnsFileNotFoundException()
        {
            string path = @"testfiles/wrongfile.xml";

            Action action = () => xmlFileReader.ReadFile(path);

            Assert.Throws<FileNotFoundException>(action);
        }
    }
  
}
