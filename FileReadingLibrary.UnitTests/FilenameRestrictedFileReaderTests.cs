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
        FileReader filenameRestrictedFileReader;

        public FilenameRestrictedFileReaderTests()
        {
            filenameRestrictedFileReader = new FilenameRestrictedFileReader(new TextFileReader());
        }

        [Fact]
        public void ReadFile_InvalidFilename_ReturnsSecurityException()
        {
            string path = @"testfiles/testfile.txt";

            Action action = () => filenameRestrictedFileReader.ReadFile(path);

            Assert.Throws<SecurityException>(action);
        }

        [Fact]
        public void ReadFile_ValidFilename_ReturnsContents()
        {
            string path = @"testfiles/public_testfile.txt";

            string contents = filenameRestrictedFileReader.ReadFile(path);

            Assert.Equal("Public information!", contents);
        }
    }
}
