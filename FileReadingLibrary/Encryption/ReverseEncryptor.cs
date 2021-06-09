using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadingLibrary.Encryption
{
    public class ReverseEncryptor : Encryptor
    {
        public override string DecryptFileContent(string content)
        {
            char[] charArray = content.ToCharArray();

            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
}
