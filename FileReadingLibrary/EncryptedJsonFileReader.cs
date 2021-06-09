using FileReadingLibrary.Encryption;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileReadingLibrary
{
    public class EncryptedJsonFileReader : FileReader
    {
        private Encryptor encryptor;
        public EncryptedJsonFileReader(Encryptor encryptor)
        {
            this.encryptor = encryptor;
        }
        public override string ReadFile(string filepath)
        {
            string encryptedContent = File.ReadAllText(filepath);
            string decryptedContent = encryptor.DecryptFileContent(encryptedContent);
            JsonDocument xmlDocument = JsonDocument.Parse(decryptedContent);
            return decryptedContent;
        }
    }
}
