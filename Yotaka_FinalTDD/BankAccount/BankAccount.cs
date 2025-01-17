using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotaka_FinalTDD.BankAccount
{
    public class BankAccount
    {
        public decimal _balance { get; set; }

        public decimal Deposit(decimal amount)
        {
            if (amount > 0) 
            {
                _balance += amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Can not deposite with negative value or zero");
            }
            return _balance;
        }
        public decimal Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= _balance)
            {
                _balance -= amount;
            }
            else
            {
                throw new ArgumentException("Can not withdraw the value is  more than balance");
            }
            return _balance;
        }
    }
}
