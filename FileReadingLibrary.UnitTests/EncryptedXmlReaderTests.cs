using FileReadingLibrary.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FileReadingLibrary.UnitTests
{
    public class EncryptedXmlReaderTests
    {
        FileReader encryptedReverseXmlFileReader;
        FileReader encryptedShiftXmlFileReader;

        public EncryptedXmlReaderTests()
        {
            encryptedReverseXmlFileReader = new EncryptedXmlFileReader(new ReverseEncryptor());
            encryptedShiftXmlFileReader = new EncryptedXmlFileReader(new ShiftEncryptor());
        }

        [Fact]
        public void ReadXmlFile_CorrectPath_ReturnsDecryptedFileContents()
        {
            string path = @"testfiles/devicesEncrypted.xml";

            string contents = encryptedReverseXmlFileReader.ReadFile(path);

            Assert.Equal("<Machines>\r\n  <Machine>PCGC04</Machine>\r\n</Machines>", contents);
        }
    }
}
