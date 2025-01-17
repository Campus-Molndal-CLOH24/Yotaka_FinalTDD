using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yotaka_FinalTDD.BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotaka_FinalTDD.BankAccount.Tests
{
    [TestClass()]
    public class BankAccountTests
    {
        private BankAccount _bankAccount;
        [TestInitialize]
        public void Setup()
        {
            // Initialize a fresh account before each test (aarange )
            _bankAccount = new BankAccount();
            _bankAccount.Deposit(100.0m); //initial deposit 100 
        }
        [TestMethod()]
        [DataRow(500.0, 600.0)]
        [DataRow(100.0, 200.0)]
        public void Deposit_ShouldIncreasesBalance(double depositAmount, double ExpectedBalances)
        {
            //act
            _bankAccount.Deposit((decimal)depositAmount);
            
            //assert
            Assert.AreEqual((decimal)ExpectedBalances, _bankAccount._balance, "Failed deposit money");
        }

        [TestMethod]
        [DataRow(-100.0)] //negative value
        public void Deposit_NegativeValue_ShouldThrowException(double depositAmount)
        {
            //act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _bankAccount.Deposit((decimal)depositAmount), "Failed deposit money with exception");
        }

        [TestMethod()]
        [DataRow(50.0, 50.0)]
        [DataRow(100.0, 0.0)]
        public void Withdraw_ShoulddecreasesBalances(double withdrawAmount, double ExpectedBalances)
        {
            //act
            _bankAccount.Withdraw((decimal)withdrawAmount);
            //assert
            Assert.AreEqual((decimal)ExpectedBalances, _bankAccount._balance, "Failed withdraw money");

        }
        //withdraw more than balance
        [TestMethod()]
        [DataRow(200.0)]
        public void Withdraw_MoreThanBalance_ShouldThrowException(double withdrawAmount)
        {
            //act and assert
            Assert.ThrowsException<ArgumentException>(() => _bankAccount.Withdraw((decimal)withdrawAmount), "Failed withdraw money with exception");
        }
    }
}