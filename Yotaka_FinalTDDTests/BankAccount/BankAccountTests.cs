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
            _bankAccount = new BankAccount();
            _bankAccount.Deposit(100.0m); 
        }


        //increases correct balances
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


        //can not accept negative value
        [TestMethod]
        [DataRow(-100.0)] //negative value
        public void Deposit_NegativeValue_ShouldThrowException(double depositAmount)
        {
            //act and assert
            Assert.ThrowsException<ArgumentException>(() => _bankAccount.Deposit((decimal)depositAmount), "Failed deposit money with exception");
        }


        // deposit cannot accept zero value
        [TestMethod()]
        public void Deposit_ShouldThrowArgumentException_WhenAmountIsZero()
        {
            // act and assert
            Assert.ThrowsException<ArgumentException>(() => _bankAccount.Deposit(0), "Failed deposit money with exception");
        }


        //withdraw return correct balances
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


        //max withdraw 500,000 per day
        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Withdraw_maxwithdraw_ShouldThrowExcep() 
        {
            //arrange
            decimal maxwithdraw = 500_000m;
            _bankAccount.Deposit(maxwithdraw);
            //act
            _bankAccount.Withdraw(maxwithdraw + 1); //withdraw more than maxwithdraw (trigger invalid exception)

        }
    }
}