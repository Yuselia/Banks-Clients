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
        public static string[] Separate(string text, string[] separatingString)
        {
            string[] parts = text.Split(separatingString, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = parts[i].Trim('\n', '\r');
            }
            return parts;
        }

        /// <summary>
        /// Is string "Bank: " present in text?
        /// </summary>
        /// <param name="text">Text from file</param>
        /// <returns>Return true if "Bank: " present in text</returns>
        public static bool BankPresentInText(string text)
        {
            bool bankPresent=false;
            StringBuilder temp = new StringBuilder();
            for (int i=0; i<6; i++)
            {
                temp.Append(text[i]);
            }
            int control = String.Compare(Convert.ToString(temp), Program.separatingOnBlocks);
            if (control==0)
                bankPresent=true;
            else Console.WriteLine("There are no banks in file");
            return bankPresent;
        }

        /// <summary>
        /// Analise text from file and create banks
        /// </summary>
        /// <param name="text">text from file</param>
        /// <returns>List of banks</returns>
        public static List<Bank> GetBanks(string text)
        {
            List<Bank> banks = new List<Bank>();
                string[] blocks = Separate(text, new string[] { Program.separatingOnBlocks });
                foreach (string block in blocks)
                {
                    string[] partsInBlock = Separate(block, new string[] { Program.separatingOnBanksAndClients });
                    Bank bank = new Bank();
                    bank = bank.CreateBank(partsInBlock[0]);
                    banks.Add(bank);
                    bank.clients = new List<Client>();

                    for (int i = 1; i < partsInBlock.Length; i++)
                    {
                        string[] nameAndDate = Separate(partsInBlock[i], new string[] { Program.separatingOnNameAndDate });
                        Client client = new Client();
                        client = client.CreateClient(nameAndDate[0], nameAndDate[1], bank);
                        bank.clients.Add(client);
                        client.Bank = bank;
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
