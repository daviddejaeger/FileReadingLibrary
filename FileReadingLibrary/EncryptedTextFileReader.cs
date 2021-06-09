using FileReadingLibrary.Encryption;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadingLibrary
{
    public class EncryptedTextFileReader: FileReader
    {
        private Encryptor encryptor;
        public EncryptedTextFileReader(Encryptor encryptor)
        {
            this.encryptor = encryptor;
        }
        public override string ReadFile(string filepath)
        {
            string encryptedContent = File.ReadAllText(filepath);
            string decryptedContent = encryptor.DecryptFileContent(encryptedContent);
            return decryptedContent;
        }
    }
}
