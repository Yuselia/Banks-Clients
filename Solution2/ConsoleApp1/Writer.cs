using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Writer
    {
        /// <summary>
        /// Write list of banks
        /// </summary>
        /// <param name="bankList">banks, which need be writed</param>
        public static void WriteBanks(List<Bank> bankList)
        {
            foreach (Bank b in bankList)
            {
                Console.WriteLine(String.Concat(b.Name, ": "));
                foreach (Client c in b.clients)
                {
                    Console.WriteLine(c.Name);
                    Console.WriteLine(c.Date);
                }
                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// Write list of clients
        /// </summary>
        /// <param name="bankList">banks, which contains client, who need be writed</param>
        public static void WriteClients(List<Bank> bankList)
        {
            foreach (Bank b in bankList)
            {
                foreach (Client c in b.clients)
                    Console.WriteLine(String.Concat("\n", c.Name, "\n", c.Date, "\n", c.Bank.Name, "\n"));
            }
        }

        /// <summary>
        /// For choose: what list (bank or clients) will be write
        /// </summary>
        /// <param name="banks">banks</param>
        public static void Chose(List<Bank> banks)
        {
            Console.WriteLine("Do you want to write list of banks or clients?\n Write 'b' to write banks.\n Write 'c' to write clients");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "b":
                    Writer.WriteBanks(banks);
                    break;
                case "c":
                    Writer.WriteClients(banks);
                    break;
                default:
                    return;
            }
        }
    }
}
