using FileReadingLibrary.Encryption;
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

            if (options.FileType == FileTypeEnum.Text)
            {
                if (options.EncryptionMechanism == EncryptionMechanismEnum.None)
                {
                    fileReader = new TextFileReader();
                }
                else if (options.EncryptionMechanism == EncryptionMechanismEnum.Reverse)
                {
                    fileReader = new EncryptedTextFileReader(new ReverseEncryptor());
                }
                else if (options.EncryptionMechanism == EncryptionMechanismEnum.Shift)
                {
                    fileReader = new EncryptedTextFileReader(new ShiftEncryptor());
                }
            }
            else if (options.FileType == FileTypeEnum.Xml)
            {
                if (options.EncryptionMechanism == EncryptionMechanismEnum.None)
                {
                    fileReader = new XmlFileReader();
                }
                else if (options.EncryptionMechanism == EncryptionMechanismEnum.Reverse)
                {
                    fileReader = new EncryptedXmlFileReader(new ReverseEncryptor());
                }
                else if (options.EncryptionMechanism == EncryptionMechanismEnum.Shift)
                {
                    fileReader = new EncryptedXmlFileReader(new ShiftEncryptor());
                }
            }
            else if (options.FileType == FileTypeEnum.Json)
            {
                if (options.EncryptionMechanism == EncryptionMechanismEnum.None)
                {
                    fileReader = new JsonFileReader();
                }
                else if (options.EncryptionMechanism == EncryptionMechanismEnum.Reverse)
                {
                    fileReader = new EncryptedJsonFileReader(new ReverseEncryptor());
                }
                else if (options.EncryptionMechanism == EncryptionMechanismEnum.Shift)
                {
                    fileReader = new EncryptedJsonFileReader(new ShiftEncryptor());
                }
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
