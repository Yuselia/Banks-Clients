using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Bank
    {
        public Bank()
        {
            clients = new List<Client>();
        }

        /// <summary>
        /// List with banks clients
        /// </summary>
        public List<Client> clients { get; private set;  }

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
        /// <returns>Bank, which was created</returns>
        public static Bank CreateBank(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new BankException("Bank's name is empty");
            }
            Bank bank = new Bank();
            bank.Name = text;
            return bank;
        }
    }
}
