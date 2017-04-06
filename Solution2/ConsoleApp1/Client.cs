using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Client
    {
        /// <summary>
        /// Getter and setter for Name
        /// </summary>
        public string Name
        {
            get; private set;
        }

        /// <summary>
        /// Getter and setter for Date
        /// </summary>
        public string Date
        {
            get; private set;
        }

        /// <summary>
        /// Getter and setter for Bank
        /// </summary>
        public Bank Bank
        {
            get; set;
        }

        /// <summary>
        /// Creating a client
        /// </summary>
        /// <param name="name">string, which contains name of client</param>
        /// <param name="date">string, which contains name of client</param>
        /// <param name="bank">Bank, which client in</param>
        /// <returns>Client, which was created</returns>
        public Client CreateClient(string name, string date, Bank bank)
        {
            Client client = new Client();
            client.Name = name;
            client.Date = date;
            client.Bank = bank;
            return client;
        }
    }
}
