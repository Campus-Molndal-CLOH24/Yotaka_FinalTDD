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
        public const decimal MaxWithdraw = 500_000m; 

        public void Deposit(decimal amount)
        {
            
            if (amount <= 0)
            {
                throw new ArgumentException("Deposite must be grather than zero");
            }
             _balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (amount >= MaxWithdraw)
            {
                throw new InvalidOperationException("Max withdraw 500 000 per day");
            }
            if (amount > _balance) 
            {
                throw new ArgumentException("Insuffient funds");
            }
          
            _balance -= amount;
        }
    }
}
