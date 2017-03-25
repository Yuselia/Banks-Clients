using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToFile = @"C:\Users\genesys\Documents\Visual Studio 2017\Projects\Solution2\ConsoleApp1\bin\Debug\input.txt";
            string textFromFile = System.IO.File.ReadAllText(pathToFile);

            List<Bank> banks = new List<Bank>();
            List<Client> clients = new List<Client>();

            try
            {
            string[] blocks = Separator.Separate(textFromFile, Separator.separatingOnBlocks);
            foreach (string b in blocks)
                {
                    string[] partsInBlock = Separator.Separate(b, Separator.separatingOnBanksAndClients);
                    Bank bank = new Bank();
                    bank=bank.CreateBank(partsInBlock, banks);

                    List<Client> clientsInBank = new List<Client>();

                    for (int i = 1; i < partsInBlock.Length; i++)
                    {
                        string[] namesAndDates = Separator.Separate(partsInBlock[i], Separator.separatingOnNameAndDate);
                        Client client = new Client();
                        client=client.CreateClient(namesAndDates, bank, clients);
                        client.Bank = bank;
                        clientsInBank.Add(client);
                    }
                    bank.clients = clientsInBank;
            }

            WriteBanks(banks);
            WriteClients(clients);

            void WriteBanks(List<Bank> bankList)
            {
                foreach (Bank b in bankList)
                {
                    Console.WriteLine(b.Name);
                    foreach (Client c in b.clients)
                    {
                        Console.WriteLine(c.Name);
                        Console.WriteLine(c.Date);
                    }
                }
            }

            void WriteClients(List<Client> clientsList)
            {
                foreach (Client c in clientsList)
                {
                    Console.WriteLine("\n" + c.Name + "\n" + c.Date + "\n" + c.Bank.Name);
                }
            }

            Console.Read();
            }
            catch(Exception e)
            {
                Console.WriteLine("Something was wrong");
            }
            
        }

        public class Client
        {
            private string client_Name;
            private string client_Date;
            private Bank client_Bank;

            /// <summary>
            /// Getter and setter for Name
            /// </summary>
            public string Name
            {
                get { return (client_Name); }
                set { client_Name = value; }
            }

            /// <summary>
            /// Getter and setter for Date
            /// </summary>
            public string Date
            {
                get { return (client_Date); }
                set { client_Date = value; }
            }

            /// <summary>
            /// Getter and setter for Bank
            /// </summary>
            public Bank Bank
            {
                get { return (client_Bank); }
                set { client_Bank = value; }
            }

            /// <summary>
            ///  Creating a client
            /// </summary>
            /// <param name="strings"></param>
            /// <param name="bank"></param>
            /// <param name="clients"></param>
            /// <returns></returns>
            public Client CreateClient(string[] strings, Bank bank, List<Client> clients)
            {
                Client client = new Client();
                clients.Add(client);
                client.Name = strings[0];
                client.Date = strings[1];
                client.Bank = bank;
                return client;
            }

        }

        public class Bank
        {
            private string bank_Name;

            /// <summary>
            /// List with banks clients
            /// </summary>
            public List<Client> clients;

            public string Name
            {
                get { return (bank_Name); }
                set { bank_Name = value; }
            }

            /// <summary>
            /// Creating a bank
            /// </summary>
            /// <param name="strings"></param>
            /// <param name="banks"></param>
            /// <returns></returns>
            public Bank CreateBank(string[] strings, List<Bank> banks)
            {
                Bank bank = new Bank();
                banks.Add(bank);
                bank.Name = strings[0];
                return bank;
            }

        }

        /// <summary>
        /// Separator for analise text in file
        /// </summary>
        public static class Separator
        {
            public static string[] separatingOnBlocks = { "Bank: " };
            public static string[] separatingOnBanksAndClients = { "Client: " };
            public static string[] separatingOnNameAndDate = { ", " };

            /// <summary>
            /// separate string on blocks
            /// </summary>
            /// <param name="text"></param>
            /// <param name="separatingString"></param>
            /// <returns></returns>
            static public string[] Separate(string text, string[] separatingString)
            {
                string[] parts = text.Split(separatingString, System.StringSplitOptions.RemoveEmptyEntries);
                return parts;
            }

        }
    }
}

