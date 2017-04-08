using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Checker
    {
        /// <summary>
        /// Check: Does string in text contains checking string ("Banks" or "Clients")?
        /// </summary>
        /// <param name="text">One string from text</param>
        /// <param name="controlString"></param>
        /// <returns>True if string contais checking string</returns>
        public static bool Check(string text, string controlString)
        {
            StringBuilder temp = new StringBuilder();
            for (int i = 0; i < controlString.Length; i++)
            {
                temp.Append(text[i]);
            }
            int control = String.Compare(Convert.ToString(temp), controlString);
            if (control == 0)
                return true;
            else return false;
        }
    }
}
