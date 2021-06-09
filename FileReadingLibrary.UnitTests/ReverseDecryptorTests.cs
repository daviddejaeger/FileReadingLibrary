using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FileReadingLibrary.UnitTests
{
    public class ReverseDecryptorTests
    {
        FileReader reverseDecryptorReader;

        public ReverseDecryptorTests()
        {
            reverseDecryptorReader = new ReverseEncryptedFileReader(new TextFileReader());
        }

        [Fact]
        public void ReadFile_CorrectPath_ReturnsDecryptedFileContents()
        {
            string path = @"testfiles/encryptedTestfile.txt";

            string contents = reverseDecryptorReader.ReadFile(path);

            Assert.Equal("This is a test file.", contents);
        }
    }
}
