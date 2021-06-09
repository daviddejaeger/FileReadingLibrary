using FileReadingLibrary.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FileReadingLibrary.UnitTests
{
    public class EncryptedJsonReaderTests
    {
        FileReader encryptedReverseJsonFileReader;

        public EncryptedJsonReaderTests()
        {
            encryptedReverseJsonFileReader = new EncryptedJsonFileReader(new ReverseEncryptor());
        }

        [Fact]
        public void ReadJsonFile_CorrectPath_ReturnsDecryptedFileContents()
        {
            string path = @"testfiles/encryptedAppsettings.json";

            string contents = encryptedReverseJsonFileReader.ReadFile(path);

            Assert.Equal("{\n\r  \"Logging\": \"test\"\n\r}", contents);
        }
    }
}
