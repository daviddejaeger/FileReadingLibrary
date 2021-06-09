using FileReadingLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadingLibrary
{
    public static class FileReaderFactory
    {
        public static FileReader CreateFileReader(FileOptions options)
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
                    fileReader = new ReverseDecryptor(fileReader);
                    break;
                case EncryptionMechanismEnum.Shift:
                    fileReader = new ShiftDecryptor(fileReader);
                    break;
            }

            return fileReader;
        }
    }
}
