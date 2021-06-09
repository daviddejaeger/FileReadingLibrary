using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadingLibrary.Encryption
{
    public abstract class Encryptor
    {
        public abstract string DecryptFileContent(string content);
    }
}
