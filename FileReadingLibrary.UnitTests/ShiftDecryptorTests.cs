using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FileReadingLibrary.UnitTests
{
    public class ShiftDecryptorTests
    {
        FileReader shiftDecryptorReader;

        public ShiftDecryptorTests()
        {
            shiftDecryptorReader = new ShiftDecryptor(new TextFileReader());
        }

        [Fact]
        public void ReadFile_CorrectPath_ReturnsDecryptedFileContents()
        {
            string path = @"testfiles/shiftEncryptedTestfile.txt";

            string contents = shiftDecryptorReader.ReadFile(path);

            Assert.Equal("Test", contents);
        }
    }
}
