using FileReadingLibrary.Exceptions;
using System;
using System.IO;

namespace FileReadingLibrary
{
    public class FileReader
    {
        public string ReadTextFile(string filepath)
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

        public bool IsValidTextFile(string filepath)
        {
            return Path.GetExtension(filepath).Equals(".txt", StringComparison.OrdinalIgnoreCase);
        }
    }
}
