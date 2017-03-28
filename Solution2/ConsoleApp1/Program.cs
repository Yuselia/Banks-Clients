using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public const string pathToFile = @"C:\Users\genesys\Documents\Visual Studio 2017\Projects\Solution2\ConsoleApp1\bin\Debug\input.txt";

        public const string separatingOnBlocks = "Bank: ";
        public const string separatingOnBanksAndClients = "Client: ";
        public const string separatingOnNameAndDate = ", ";

        static void Main(string[] args)
        {
            if (FindFile(pathToFile))
            {
                string textFromFile = System.IO.File.ReadAllText(pathToFile);
                List<Bank> banks = new List<Bank>();
                banks=TextAnalisator.GetBanks(textFromFile);
                Writer.Chose(banks);
                Console.Read();
            }
        }

        /// <summary>
        /// Analise: exist file or no
        /// </summary>
        /// <param name="text">string, which contains path to file</param>
        /// <returns></returns>
        private static bool FindFile(string text)
        {
            if (!System.IO.File.Exists(text))
            {
                Console.WriteLine("Doesn't exist file. Do you want to find it again? Y/N");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "Y":
                        return FindFile(text);
                    case "N":
                        return false;
                    default:
                        return false;
                }
            }
            return true;
        }
    }
}

