using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class BankException: Exception
    {
        public BankException(string message) : base(message)
        {

        }
    }
}
