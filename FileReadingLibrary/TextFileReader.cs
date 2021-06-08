using FileReadingLibrary.Exceptions;
using System;
using System.IO;

namespace FileReadingLibrary
{
    public class TextFileReader : FileReader
    {
        public override string ReadFile(string filepath)
        {
            if (IsValidTextFile(filepath))
            {
                return File.ReadAllText(filepath);
            }
            else
            {
                throw new InvalidFileTypeException(filepath, "*.txt");
            }
        }

        private bool IsValidTextFile(string filepath)
        {
            return Path.GetExtension(filepath).Equals(".txt", StringComparison.OrdinalIgnoreCase);
        }
    }
}
