using System;

namespace FileReadingLibrary.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReaderOptions options = new FileReaderOptions();

            bool useRoleBasedSecurity = false;

            bool validfileTypeEntered = false;
            do
            {
                Console.WriteLine("Specify (by number) which file type you want to read (0 = text, 1 = xml, 2 = json): ");
                string fileType = Console.ReadLine();

                if (fileType.Equals("0",StringComparison.OrdinalIgnoreCase) || fileType.Equals("1", StringComparison.OrdinalIgnoreCase) || fileType.Equals("2", StringComparison.OrdinalIgnoreCase))
                {
                    validfileTypeEntered = true;
                    options.FileType = (Enums.FileTypeEnum)Convert.ToInt32(fileType);
                }
                else
                {
                    Console.WriteLine("Try again, Please enter a valid number");
                }

            } while (!validfileTypeEntered);

            bool validEncryptionEntered = false;
            do
            {
                Console.WriteLine("Use Encryption (Y/N):");
                string encryption = Console.ReadLine();

                if (encryption.Equals("Y", StringComparison.OrdinalIgnoreCase) || encryption.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    validEncryptionEntered = true;
                    if (encryption.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        options.EncryptionMechanism = Enums.EncryptionMechanismEnum.Reverse;
                    }                 
                }
                else
                {
                    Console.WriteLine("Try again, please answer with Y or N");
                }

            } while (!validEncryptionEntered);

            bool validSecurityEntered = false;
            do
            {
                Console.WriteLine("Use role based security (Y/N):");
                string security = Console.ReadLine();

                if (security.Equals("Y", StringComparison.OrdinalIgnoreCase) || security.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    validSecurityEntered = true;
                    if (security.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        useRoleBasedSecurity = true;
                    }                
                }
                else
                {
                    Console.WriteLine("Try again, please answer with Y or N");
                }

            } while (!validSecurityEntered);

            if (useRoleBasedSecurity)
            {
                bool validRoleEntered = false;
                do
                {
                    Console.WriteLine("Specify (by number) which role you are (0 = admin, 1 = user): ");
                    string fileType = Console.ReadLine();

                    if (fileType.Equals("0", StringComparison.OrdinalIgnoreCase) || fileType.Equals("1", StringComparison.OrdinalIgnoreCase))
                    {
                        validRoleEntered = true;
                        options.FileType = (Enums.FileTypeEnum)Convert.ToInt32(fileType);
                    }
                    else
                    {
                        Console.WriteLine("Try again, Please enter a valid number");
                    }

                } while (!validRoleEntered);
            }

            
            bool validFileEntered = false;
            do
            {
                Console.WriteLine("Please enter the path of the text file:");
                string path = Console.ReadLine();

                try
                {
                    FileReader fileReader = FileReaderFactory.CreateFileReader(options);
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
