using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Bank
    {
        /// <summary>
        /// List with banks clients
        /// </summary>
        public List<Client> clients { get; set;  }

        /// <summary>
        /// Getter and setter for Name
        /// </summary>
        public string Name
        {
            get; private set;
        }

        /// <summary>
        /// Creating a bank
        /// </summary>
        /// <param name="text">String, which contains name of bank</param>
        /// <returns></returns>
        public Bank CreateBank(string text)
        {
            Bank bank = new Bank();
            bank.Name = text;
            clients = new List<Client>();
            return bank;
        }
    }
}
