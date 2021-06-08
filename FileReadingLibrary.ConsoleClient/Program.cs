using System;

namespace FileReadingLibrary.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            bool validFileEntered = false;
            do
            {
                Console.WriteLine("Please enter the path of the text file:");
                string path = Console.ReadLine();

                try
                {
                    FileReader fileReader = new TextFileReader();
                    Console.WriteLine(fileReader.ReadFile(path));
                    validFileEntered = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n");
                    Console.WriteLine("Please try again");
                }
             
            } while (!validFileEntered);
            
        }
    }
}
