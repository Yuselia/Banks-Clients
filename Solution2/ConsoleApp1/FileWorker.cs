using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class FileWorker
    {
        /// <summary>
        /// Analise: exist file or no
        /// </summary>
        /// <param name="file">string, which contains path to file</param>
        /// <returns>True if file exists, false if file no exists</returns>
        public static bool FindFile(string file)
        {
            if (!System.IO.File.Exists(file))
            {
                Console.WriteLine("Doesn't exist file. Do you want to find it again? Y/N");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "Y":
                        return FindFile(file);
                    case "N":
                        return false;
                    default:
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check file no empty
        /// </summary>
        /// <param name="text">Text in file</param>
        /// <returns>True if file contains text, false if file empty</returns>
        public static bool FileNoEmpty(string text)
        {
            if (text == "")
            {
                Console.WriteLine("File is Empty");
                Console.Read();
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Reading text from file
        /// </summary>
        /// <param name="file">String with path to file</param>
        /// <returns>string with text from file</returns>
        public static string ReadText(string file)
        {
            string textFromFile = System.IO.File.ReadAllText(file);
            return textFromFile;
        }
    }

}
