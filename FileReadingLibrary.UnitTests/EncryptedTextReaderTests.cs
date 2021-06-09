using FileReadingLibrary.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FileReadingLibrary.UnitTests
{
    public class EncryptedTextReaderTests
    {
        FileReader encryptedReverseTextFileReader;
        FileReader encryptedShiftTextFileReader;

        public EncryptedTextReaderTests()
        {
            encryptedReverseTextFileReader = new EncryptedTextFileReader(new ReverseEncryptor());
            encryptedShiftTextFileReader = new EncryptedTextFileReader(new ShiftEncryptor());
        }

        [Fact]
        public void ReadTextFile_CorrectPath_ReturnsDecryptedFileContents()
        {
            string path = @"testfiles/encryptedTestfile.txt";

            string contents = encryptedReverseTextFileReader.ReadFile(path);

            Assert.Equal("This is a test file.", contents);
        }

        [Fact]
        public void ReadFile_CorrectPath_ReturnsDecryptedFileContents()
        {
            string path = @"testfiles/shiftEncryptedTestfile.txt";

            string contents = encryptedShiftTextFileReader.ReadFile(path);

            Assert.Equal("Test", contents);
        }
    }
}
