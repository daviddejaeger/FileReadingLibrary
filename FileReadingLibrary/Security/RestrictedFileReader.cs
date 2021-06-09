using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadingLibrary.Security
{
    public abstract class RestrictedFileReader : FileReader
    {
        public abstract void CheckAuthorization(string filepath);
    }
}
