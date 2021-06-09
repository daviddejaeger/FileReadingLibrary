using FileReadingLibrary.Enums;

namespace FileReadingLibrary
{
    public class FileReaderOptions
    {
        public FileTypeEnum FileType { get; set; } = FileTypeEnum.Text;
        public EncryptionMechanismEnum EncryptionMechanism { get; set; } = EncryptionMechanismEnum.None;
        public SecurityRoleEnum SecurityRole { get; set; } = SecurityRoleEnum.User;
    }
}
