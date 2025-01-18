using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yotaka_FinalTDD.Booksystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yotaka_FinalTDD.Booksystem.Interface;
using NSubstitute;

namespace Yotaka_FinalTDD.Booksystem.Tests
{
    [TestClass()]
    public class BookingServiceFacadeTests
    {
        //mock data
        private readonly BookingSystem _bookingSystem;
        private readonly BookingServiceFacade _bookingServiceFacade;
        private readonly IRoomsystem _iRoomsystem;
        public BookingServiceFacadeTests()
        {
            _iRoomsystem = Substitute.For<IRoomsystem>();
            _bookingSystem = new BookingSystem(_iRoomsystem); // Inject the mock into BookingSystem
            _bookingServiceFacade = new BookingServiceFacade(_bookingSystem);
        }

        //return true when booking is successful
        [TestMethod()]
        public async Task  BookingServiceFacade_ShouldReturnTrue_whenBookingIssucces()
        {
            //arrange
            var startDate = new DateTime(2025, 01, 10, 0, 0, 0, DateTimeKind.Utc);
            var endDate = new DateTime(2025, 01, 12, 0, 0, 0, DateTimeKind.Utc);
            _iRoomsystem.BookTimeSlot(startDate, endDate).Returns(Task.FromResult(true));

            //act
            var result = await _bookingServiceFacade.BookSlot(startDate, endDate);
            //assert
            Assert.IsTrue(result, "Booking should be successful");
            await _iRoomsystem.Received().BookTimeSlot(startDate, endDate);
        }

        //return false when booking is not successful
        [TestMethod()]
        public async Task BookingServiceFacade_ShouldReturnFalse_WhenBookingFails()
        {
            //arrange
            //it will return false when booking is the same date
            var startDate = new DateTime(2025, 01, 10, 0, 0, 0, DateTimeKind.Utc);
            var endDate = new DateTime(2025, 01, 12, 0, 0, 0, DateTimeKind.Utc);
            _iRoomsystem.BookTimeSlot(startDate, endDate).Returns(Task.FromResult(false));
            //act
            var result = await _bookingServiceFacade.BookSlot(startDate, endDate);
            //assert
            Assert.IsFalse(result, "Booking should not be successful");
            await _iRoomsystem.Received().BookTimeSlot(startDate, endDate);
        }

        //return false when booking start date is after end date
        [TestMethod()]
        public async Task BookingServiceFacade_ShouldReturnFalse_WhenStartDateIsAfterEndDate()
        {
            //arrange
            //it will return false when booking start date is after end date
            var startDate = new DateTime(2025, 01, 12, 0, 0, 0, DateTimeKind.Utc);
            var endDate = new DateTime(2025, 01, 10, 0, 0, 0, DateTimeKind.Utc);
            //act
            var result = await _bookingServiceFacade.BookSlot(startDate, endDate);
            //assert
            Assert.IsFalse(result, "Booking should not be successful");
            await _iRoomsystem.DidNotReceive().BookTimeSlot(startDate, endDate);
        }

        //it will return false if user left the date empty
        [TestMethod()]
        public async Task BookingServiceFacade_ShouldThrowArgumentException_WhenDateIsNullOrEmpty()
        {
            //arrange
            //it will throw an exception when date is null
            DateTime? startDate = null;
            var endDate = new DateTime(2025, 01, 12, 0, 0, 0, DateTimeKind.Utc);
            _iRoomsystem.BookTimeSlot(Arg.Any<DateTime>(), endDate).Returns(Task.FromResult(true));
            //act
            var ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _bookingServiceFacade.BookSlot(startDate ?? default(DateTime), endDate));
            //assert
            Assert.AreEqual("Date cannot be null", ex.Message);
            await _iRoomsystem.DidNotReceive().BookTimeSlot(Arg.Any<DateTime>(), endDate);
        }
    }
}