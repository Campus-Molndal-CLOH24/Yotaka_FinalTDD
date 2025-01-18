using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yotaka_FinalTDD.Booksystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace Yotaka_FinalTDD.Booksystem.Tests
{
    [TestClass()]
    public class BookingSystemTests
    {
        [TestMethod()]
        public void BookTimeSlot_EnsureAddCorrect()
        {
            // Arrange
            BookingSystem bookingSystem = new BookingSystem();
            DateTime startDate = new DateTime(2021, 12, 24, 12, 0, 0);
            DateTime endDate = new DateTime(2021, 12, 24, 13, 0, 0);
            // Act
            var result = bookingSystem.BookTimeSlot(startDate, endDate);
            // Assert
            Assert.IsTrue(result.Result, "Fail to add booking");
        }

        [TestMethod()]
        public void GetAvailableTimeSlotsTest()
        {
            Assert.Fail();
        }
    }
}