using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace FileReadingLibrary.Security
{
    public class FilenameRestrictedFileReader : RestrictedFileReader
    {
        FileReader fileReader;
        public FilenameRestrictedFileReader(FileReader fileReader)
        {
            this.fileReader = fileReader;
        }

        public override string ReadFile(string filepath)
        {
            CheckAuthorization(filepath);
            return fileReader.ReadFile(filepath);          
        }

        public override void CheckAuthorization(string filepath)
        {
            if (!filepath.Contains("public"))
            {
                throw new SecurityException("Invalid role to view this file");
            }
        }
    }
}
