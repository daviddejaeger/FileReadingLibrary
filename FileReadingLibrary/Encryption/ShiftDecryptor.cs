using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadingLibrary
{
    public class ShiftDecryptor : Decryptor
    {
        FileReader fileReader;
        public ShiftDecryptor(FileReader fileReader)
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
            List<char> newArray = new List<char>();

            foreach (var character in charArray)
            {
                newArray.Add(Convert.ToChar(Convert.ToInt32(character) + 1));
            }

            return new string(newArray.ToArray());
        }
    }
}
