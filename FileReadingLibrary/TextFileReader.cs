using System.IO;

namespace FileReadingLibrary
{
    public class TextFileReader : FileReader
    {
        public override string ReadFile(string filepath)
        {
            return File.ReadAllText(filepath);
        }
    }
}
