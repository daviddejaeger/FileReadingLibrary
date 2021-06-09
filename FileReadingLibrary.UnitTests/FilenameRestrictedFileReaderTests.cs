using FileReadingLibrary.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FileReadingLibrary.UnitTests
{
    public class FilenameRestrictedFileReaderTests
    {
        FileReader filenameRestrictedTextFileReader;
        FileReader filenameRestrictedXmlFileReader;
        FileReader filenameRestrictedJsonFileReader;

        public FilenameRestrictedFileReaderTests()
        {
            filenameRestrictedTextFileReader = new FilenameRestrictedFileReader(new TextFileReader());
            filenameRestrictedXmlFileReader = new FilenameRestrictedFileReader(new XmlFileReader());
            filenameRestrictedJsonFileReader = new FilenameRestrictedFileReader(new JsonFileReader());
        }

        [Fact]
        public void ReadTextFile_InvalidFilename_ReturnsSecurityException()
        {
            string path = @"testfiles/testfile.txt";

            Action action = () => filenameRestrictedTextFileReader.ReadFile(path);

            Assert.Throws<SecurityException>(action);
        }

        [Fact]
        public void ReadTextFile_ValidFilename_ReturnsContents()
        {
            string path = @"testfiles/public_testfile.txt";

            string contents = filenameRestrictedTextFileReader.ReadFile(path);

            Assert.Equal("Public information!", contents);
        }

        [Fact]
        public void ReadXmlFile_InvalidFilename_ReturnsSecurityException()
        {
            string path = @"testfiles/devices.xml";

            Action action = () => filenameRestrictedXmlFileReader.ReadFile(path);

            Assert.Throws<SecurityException>(action);
        }

        [Fact]
        public void ReadXmlFile_ValidFilename_ReturnsContents()
        {
            string path = @"testfiles/public_devices.xml";

            string contents = filenameRestrictedXmlFileReader.ReadFile(path);

            Assert.Equal("<PublicMachines>\r\n  <Machine>PCGC10</Machine>\r\n</PublicMachines>", contents);
        }

        [Fact]
        public void ReadJsonFile_InvalidFilename_ReturnsSecurityException()
        {
            string path = @"testfiles/appsettings_ok.Development.json";

            Action action = () => filenameRestrictedJsonFileReader.ReadFile(path);

            Assert.Throws<SecurityException>(action);
        }

        [Fact]
        public void ReadJsonFile_ValidFilename_ReturnsContents()
        {
            string path = @"testfiles/appsettings_public.Development.json";

            string contents = filenameRestrictedJsonFileReader.ReadFile(path);

            Assert.Equal("{\r\n  \"Logging\": {\r\n    \"LogLevel\": {\r\n      \"Default\": \"Information\",\r\n      \"Microsoft\": \"Information\"\r\n    }\r\n  }\r\n}\r\n", contents);
        }
    }
}
