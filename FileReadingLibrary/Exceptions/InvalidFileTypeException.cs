using System.IO;

namespace FileReadingLibrary.Exceptions
{
    public class InvalidFileTypeException : IOException
    {
        public InvalidFileTypeException(string path, string acceptedTypeMask) :
            base(string.Format(
                "File type '{0}' does not match the expected extension: '{1}'",
                path,
                acceptedTypeMask))
        { }
    }
}
