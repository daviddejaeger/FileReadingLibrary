using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadingLibrary.Encryption
{
    public class ShiftEncryptor : Encryptor
    {
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
