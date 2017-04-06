using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class DialogWithUser
    {
        /// <summary>
        /// Show question and get string with user's answer 
        /// </summary>
        /// <param name="question">string wth question</param>
        /// <returns>string with answer</returns>
        public static string Ask(string question)
        {
            Console.WriteLine(question);
            string answer = Console.ReadLine();
            return answer;
        }

        /// <summary>
        /// Convert string with answer to bool
        /// </summary>
        /// <param name="answer">String with user's answer</param>
        /// <returns>Returt true if answer is "1"</returns>
        public static bool Choose(string answer)
        {
            if (answer == "1") return true;
            else return false;
        }
    }
}
