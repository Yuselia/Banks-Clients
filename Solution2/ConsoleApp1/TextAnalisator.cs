using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TextAnalisator
    {
        /// <summary>
        /// separate string on blocks
        /// </summary>
        /// <param name="text">Text, which must be separate</param>
        /// <param name="separatingString">String, which separate text</param>
        /// <returns></returns>
        static public string[] Separate(string text, string[] separatingString)
        {
            string[] parts = text.Split(separatingString, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = parts[i].Trim('\n', '\r');
            }
            return parts;
        }

        /// <summary>
        /// Create objects Banks and Clients in each bank after analise text from file
        /// </summary>
        /// <param name="text">text, which contains information about banks and clients</param>
        /// <returns></returns>
        public static List<Bank> GetBanks(string text)
        {
            List<Bank> banks = new List<Bank>();
            string[] blocks = Separate(text, new string[] { Program.separatingOnBlocks});
            foreach (string block in blocks)
            {
                string[] partsInBlock = Separate(block, new string[] { Program.separatingOnBanksAndClients});
                Bank bank = new Bank();
                bank = bank.CreateBank(partsInBlock[0]);
                banks.Add(bank);
                bank.clients = new List<Client>();

                for (int i = 1; i < partsInBlock.Length; i++)
                {
                    string[] nameAndDate = Separate(partsInBlock[i], new string[] { Program.separatingOnNameAndDate});
                    Client client = new Client();
                    client = client.CreateClient(nameAndDate[0], nameAndDate[1], bank);
                    bank.clients.Add(client);
                    client.Bank = bank;
                }
            }
            return banks;
        }
    }
}
