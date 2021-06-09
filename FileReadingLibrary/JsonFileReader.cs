using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileReadingLibrary
{
    public class JsonFileReader : FileReader
    {
        public override string ReadFile(string filepath)
        {
            string content = File.ReadAllText(filepath);
            JsonDocument jsonDocument = JsonDocument.Parse(content);
            return content;
        }
    }
}
