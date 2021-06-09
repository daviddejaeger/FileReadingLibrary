using System;
using System.IO;
using Xunit;

namespace FileReadingLibrary.UnitTests
{
    public class TextReaderTests
    {
        FileReader textFileReader;

        public TextReaderTests()
        {
            textFileReader = new TextFileReader();
        }

        [Fact]
        public void ReadFile_CorrectPath_ReturnsFileContents()
        {
            string path = @"testfiles/testfile.txt";

            string contents = textFileReader.ReadFile(path);

            Assert.Equal("This is a test file.", contents);
        }

        [Fact]
        public void ReadFile_IncorrectPath_ReturnsFileNotFoundException()
        {
            string path = @"testfiles/wrongfile.txt";

            Action action = () => textFileReader.ReadFile(path);

            Assert.Throws<FileNotFoundException>(action);
        }
    }
}
