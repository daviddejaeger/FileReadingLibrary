using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadingLibrary
{
    public abstract class EncryptedFileReader : FileReader
    {
        public abstract string DecryptFileContent(string content);
    }
}
