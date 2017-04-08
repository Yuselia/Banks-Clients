using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Writer
    {
        public delegate void WritingFunction(string s);
        public delegate string ListToStringFunction<T>(List<T> objects);

        public static event Action WritingComplete;

        /// <summary>
        /// Write objects (banks or clients)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myDelegate1">Writing function</param>
        /// <param name="myDelegate2">Function, which take list with objects and convert it to string</param>
        /// <param name="objects">List with banks or clients</param>
        public static void Write<T>(WritingFunction myDelegate1, ListToStringFunction<T> myDelegate2, List<T> objects)
        {
            string s = myDelegate2(objects);
            myDelegate1(s);
            WritingComplete();
        }
    }
}
