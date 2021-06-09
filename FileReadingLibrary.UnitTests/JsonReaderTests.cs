using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace FileReadingLibrary.UnitTests
{
    public class JsonReaderTests
    {
        FileReader jsonFileReader;

        public JsonReaderTests()
        {
            jsonFileReader = new JsonFileReader();
        }

        [Fact]
        public void ReadFile_CorrectPath_ReturnsFileContents()
        {
            string path = @"testfiles/appsettings.development.json";

            string contents = jsonFileReader.ReadFile(path);

            Assert.Equal("{\r\n  \"Logging\": {\r\n    \"LogLevel\": {\r\n      \"Default\": \"Information\",\r\n      \"Microsoft\": \"Information\"\r\n    }\r\n  }\r\n}\r\n", contents);
        }
        [Fact]
        public void ReadFile_IncorrectJson_ReturnsJsonException()
        {
            string path = @"testfiles/appsettingswrong.development.json";

            Action action = () => jsonFileReader.ReadFile(path);

            Assert.ThrowsAny<JsonException>(action);
        }

        [Fact]
        public void ReadFile_IncorrectPath_ReturnsFileNotFoundException()
        {
            string path = @"testfiles/wrongfile.json";

            Action action = () => jsonFileReader.ReadFile(path);

            Assert.Throws<FileNotFoundException>(action);
        }
    }
}
