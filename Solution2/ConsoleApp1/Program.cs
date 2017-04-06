using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static string pathToInputFile = "";
        public static string pathToOutputFile = ""; 

        public const string separatingOnBlocks = "Bank: ";
        public const string separatingOnBanksAndClients = "Client: ";
        public const string separatingOnNameAndDate = ", ";

        public const string question1 = "Do you want to write banks or clients?\n Write '1' to write banks.\n Write '2' to write clients";
        public const string question2 = "Do you want to write to console or to file?\n Write '1' to write to console.\n Write '2' to write to file";

        static void Main(string[] args)
        {
            ReadSetting("InputFile", "OutputFile");
            List<Bank> banks = new List<Bank>();
            List<Client> clients = new List<Client>();
            Writer.WritedToFile += EndWritingToFile;
            TextAnalisator.BanksAndClientsWereCreated += EndTextAnalise;

            if (FileWorker.FindFile(pathToInputFile)&&(FileWorker.FileNoEmpty(FileWorker.ReadText(pathToInputFile))))
            {
                string textFromFile= FileWorker.ReadText(pathToInputFile);
                if (TextAnalisator.BankPresentInText(textFromFile))
                {
                    banks = TextAnalisator.GetBanks(textFromFile);
                    clients = TextAnalisator.GetClients(banks);

                    string answerBanks = DialogWithUser.Ask(question1);
                    string answerConsole = DialogWithUser.Ask(question2);

                    if (!(DialogWithUser.Choose(answerConsole)))
                    {
                        if (FileWorker.FindFile(pathToOutputFile))
                        {
                            if (DialogWithUser.Choose(answerBanks))
                            {
                                Writer.Write<Bank>(WriteOnFile, GetStringWithBanks, banks);
                            }
                            else Writer.Write<Client>(WriteOnFile, GetStringWithClients, clients);
                        }
                    }
                    else
                        if (DialogWithUser.Choose(answerBanks))
                    {
                        Writer.Write<Bank>(WriteOnConsole, GetStringWithBanks, banks);
                    }
                    else Writer.Write<Client>(WriteOnConsole, GetStringWithClients, clients);
                }
                Writer.WritedToFile -= EndWritingToFile;
                TextAnalisator.BanksAndClientsWereCreated -= EndTextAnalise;
                Console.Read();
            }
        }

        private static void WriteOnConsole(string s)
        {
            Console.WriteLine(s);
        }

        private static void WriteOnFile(string s)
        {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(pathToOutputFile, true))
                {
                    file.WriteLine(s);
                }
                //Writer.WritedToFile(); //Why I can't do it? 
        }

        private static void EndTextAnalise()
        {
            Console.WriteLine("End analise file, were created banks and clients");
        }

        private static void EndWritingToFile()
        {
            Console.WriteLine("Information was write to file");
        }

        private static string GetStringWithBanks(List<Bank> bankList)
        {
            StringBuilder stringWithBanks = new StringBuilder();
            stringWithBanks.Append("Banks:");
            foreach (Bank b in bankList)
            {
                stringWithBanks.Append("\r\n");
                stringWithBanks.Append(b.Name);
                stringWithBanks.Append(": ");
                foreach (Client c in b.clients)
                {
                    stringWithBanks.Append("\r\n");
                    stringWithBanks.Append(c.Name);
                    stringWithBanks.Append("\r\n");
                    stringWithBanks.Append(c.Date);
                    stringWithBanks.Append("\r\n");
                }
            }
            return stringWithBanks.ToString();
        }

        private static string GetStringWithClients(List<Client> clients)
        {
            StringBuilder stringWithClients = new StringBuilder();
            stringWithClients.Append("Clients:");
                foreach (Client c in clients)
                    stringWithClients.Append(String.Concat("\r\n", c.Name, "\r\n", c.Date, "\r\n", c.Bank.Name, "\r\n"));
            return stringWithClients.ToString();
        }

        private static void ReadSetting(string key1, string key2)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                pathToInputFile = appSettings[key1] ?? "Not Found";
                pathToOutputFile = appSettings[key2] ?? "Not Found";
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }
    }
}

