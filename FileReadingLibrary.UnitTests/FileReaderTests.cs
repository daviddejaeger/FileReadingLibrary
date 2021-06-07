using FileReadingLibrary.Exceptions;
using System;
using System.IO;
using Xunit;

namespace FileReadingLibrary.UnitTests
{
    public class FileReaderTests
    {
        FileReader fileReader;

        public FileReaderTests()
        {
            fileReader = new FileReader();
        }

        [Fact]
        public void ReadTextFile_CorrectPath_ReturnsFileContents()
        {
            string path = @"testfile.txt";

            string contents = fileReader.ReadTextFile(path);

            Assert.Equal("This is a test file.", contents);
        }

        [Fact]
        public void ReadTextFile_IncorrectPath_ReturnsFileNotFoundException()
        {
            string path = @"wrongfile.txt";

            Action action = () => fileReader.ReadTextFile(path);

            Assert.Throws<FileNotFoundException>(action);
        }

        [Fact]
        public void ReadTextFile_IncorrectFileType_ReturnsInvalidFileTypeException()
        {
            string path = @"icon-72x72.png";

            Action action = () => fileReader.ReadTextFile(path);

            Assert.Throws<InvalidFileTypeException>(action);
        }
    }
}
