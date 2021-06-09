using FileReadingLibrary.Encryption;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileReadingLibrary
{
    public class EncryptedXmlFileReader : FileReader
    {
        private Encryptor encryptor;
        public EncryptedXmlFileReader(Encryptor encryptor)
        {
            this.encryptor = encryptor;
        }
        public override string ReadFile(string filepath)
        {
            string encryptedContent = File.ReadAllText(filepath);
            string decryptedContent = this.encryptor.DecryptFileContent(encryptedContent);
            XDocument xmlDocument = XDocument.Parse(decryptedContent);
            return xmlDocument.ToString();
        }
    }
}
