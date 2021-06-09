using FileReadingLibrary.Enums;

namespace FileReadingLibrary
{
    public class FileOptions
    {
        public FileTypeEnum FileType { get; set; }
        public EncryptionMechanismEnum EncryptionMechanism { get; set; }
    }
}
