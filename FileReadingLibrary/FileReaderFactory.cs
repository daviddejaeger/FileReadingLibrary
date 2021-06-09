using FileReadingLibrary.Enums;
using FileReadingLibrary.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadingLibrary
{
    public static class FileReaderFactory
    {
        public static FileReader CreateFileReader(FileReaderOptions options)
        {
            FileReader fileReader = null;

            switch (options.FileType)
            {
                case FileTypeEnum.Text:
                    fileReader = new TextFileReader();
                    break;
                case FileTypeEnum.Xml:
                    fileReader = new XmlFileReader();
                    break;
            }

            switch (options.EncryptionMechanism)
            {
                case EncryptionMechanismEnum.Reverse:
                    fileReader = new ReverseEncryptedFileReader(fileReader);
                    break;
                case EncryptionMechanismEnum.Shift:
                    fileReader = new ShiftEncryptedFileReader(fileReader);
                    break;
            }

            switch (options.SecurityRole)
            {
                case SecurityRoleEnum.User:
                    fileReader = new FilenameRestrictedFileReader(fileReader);
                    break;
            }

            return fileReader;
        }
    }
}
