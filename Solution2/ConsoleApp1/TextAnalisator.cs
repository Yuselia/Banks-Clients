using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TextAnalisator
    {
        public static event Action BanksAndClientsWereCreated;

        /// <summary>
        /// separate string on blocks
        /// </summary>
        /// <param name="text">Text, which must be separate</param>
        /// <param name="separatingString">String, which separate text</param>
        /// <returns>strings after separate</returns>
        public static string[] Separate(string text, string separatingString)
        {
            string[] parts = text.Split(new string[] { separatingString }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = parts[i].Trim('\n', '\r', ' ');
            }
            return parts;
        }
        public static string[] Separate(string text, string[] separatingStrings)
        {
            string[] parts = text.Split( separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = parts[i].Trim('\n', '\r', ' ');
            }
            return parts;
        }

        /// <summary>
        /// Analise text from file and create banks
        /// </summary>
        /// <param name="text">text from file</param>
        /// <returns>List of banks</returns>
        public static List<Bank> GetBanks(string text)
        {
            List<Bank> banks = new List<Bank>();
            string[] blocks = Separate(text, Program.separatingOnBlocks );
            foreach (string block in blocks)
            {
                if (Checker.Check(block, Program.stringBank))
                {
                    string[] stringsInBlock = Separate(block, Program.separatingBlocksOnStrings);
                    string[] s = Separate(stringsInBlock[0], Program.stringBank);
                    try
                    {
                        Bank bank = Bank.CreateBank(s[0]);
                        banks.Add(bank);
                        for (int i = 1; i < stringsInBlock.Length; i++)
                        {
                            if (Checker.Check(stringsInBlock[i], Program.stringClient))
                            {
                                string[] separating = { Program.separatingOnNameAndDate, Program.stringClient };
                                string[] nameAndDate = Separate(stringsInBlock[i], separating);
                                Client client = new Client();
                                client = client.CreateClient(nameAndDate[0], nameAndDate[1], bank);
                                bank.clients.Add(client);
                                client.Bank = bank;
                            }
                            else
                            {
                                Console.WriteLine("One or more string doesn't contain string 'Client:'");
                            }
                        }
                    }
                    catch(BankException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch(IndexOutOfRangeException e)
                    {
                        Console.WriteLine("You shoud check your input file!\nSome information in file was wrong. String with wrong information wasn't created");
                    }
                }
                else
                {
                    Console.WriteLine("One or more block in text doesn't contain string 'Bank:'");
                }
            }
            BanksAndClientsWereCreated();
            return banks;
        }

        /// <summary>
        /// Get list with all clients (in all banks)
        /// </summary>
        /// <param name="banks">banks, whith client shoud be add in list</param>
        /// <returns>List with clients</returns>
        public static List<Client> GetClients(List<Bank> banks)
        {
            List<Client> clients = new List<Client>();
            foreach (Bank b in banks)
            {
                foreach (Client c in b.clients)
                    clients.Add(c);
            }
            return clients;
        }
    }
}
