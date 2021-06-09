using System;
using System.Collections.Generic;


namespace FileReadingLibrary
{
    public class ReverseDecryptor : Decryptor
    {
        FileReader fileReader;
        public ReverseDecryptor(FileReader fileReader)
        {
            this.fileReader = fileReader;
        }

        public override string ReadFile(string filepath)
        {
            string contents = fileReader.ReadFile(filepath);
            return DecryptFileContent(contents);
        }

        public override string DecryptFileContent(string content)
        {
            char[] charArray = content.ToCharArray();

            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
}
