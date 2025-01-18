using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yotaka_FinalTDD.Booksystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Yotaka_FinalTDD.Booksystem.Interface;

namespace Yotaka_FinalTDD.Booksystem.Tests
{
    [TestClass()]
    public class BookingSystemTests
    {
        [TestMethod()]
        public async Task BookTimeSlot_EnsureAddCorrect()
        {
            var mockchecker = Substitute.For<IRoomsystem>();
            mockchecker.BookTimeSlot(Arg.Any<DateTime>(), Arg.Any<DateTime>()).Returns(Task.FromResult(true));
            var booking = new BookingSystem(mockchecker);
            //act
            var result = await booking.BookTimeSlot(new DateTime(2025, 01, 10, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 01, 12, 0, 0, 0, DateTimeKind.Utc));
            //assert
            Assert.IsTrue(result, "Falied to add rooms");
            await mockchecker.Received().BookTimeSlot(new DateTime(2025, 01, 10, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 01, 12, 0, 0, 0, DateTimeKind.Utc));
        }

        //overlapping bookings are not allowed.
        [TestMethod]
        public async Task BookTimeSlot_ShouldReturnFalse_WhenTimeSlotOverlaps()
        {
            //arrange
            var mockchecker = Substitute.For<IRoomsystem>();
            var booking = new BookingSystem(mockchecker);
            var existingBooking = new Booking(new DateTime(2025, 01, 10, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 01, 12, 0, 0, 0, DateTimeKind.Utc));
            booking.Bookings.Add(existingBooking);

            var startDate = new DateTime(2025, 01, 11, 0, 0, 0, DateTimeKind.Utc);
            var endDate = new DateTime(2025, 01, 13, 0, 0, 0, DateTimeKind.Utc);

            //act
            var result = await booking.BookTimeSlot(startDate, endDate);
            //assert
            Assert.IsFalse(result, "Booking should fail when time slot overlaps with an existing booking");
           
        }

        //return true when booking is valid and time it not overlapping
        [TestMethod]
        public async Task BookTimeSlot_ShouldReturnTrue_WhenBookingIsValid()
        {
            //arrange
            var mockchecker = Substitute.For<IRoomsystem>();
            mockchecker.BookTimeSlot(Arg.Any<DateTime>(), Arg.Any<DateTime>()).Returns(Task.FromResult(true)); //ensure return true
            var booking = new BookingSystem(mockchecker);
            var existingBooking = new Booking(new DateTime(2025, 01, 10, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 01, 11, 0, 0, 0, DateTimeKind.Utc));
            booking.Bookings.Add(existingBooking);
            var startDate = new DateTime(2025, 01, 12, 0, 0, 0, DateTimeKind.Utc);
            var endDate = new DateTime(2025, 01, 13, 0, 0, 0, DateTimeKind.Utc);
            //act
            var result = await booking.BookTimeSlot(startDate, endDate);
            //assert
            Assert.IsTrue(result, "Booking should succeed when time slot does not overlap with an existing booking");
            Assert.IsTrue(booking.Bookings.Any(b => b.Starttime == startDate && b.Endtime == endDate), "New booking should be added to the bookings list");
        }

        //return false when start date is equal to end date
        [TestMethod()]
        public async Task BookTimeSlot_ShouldReturnFalse_WhenstarDatetisEqualtoEndDate()
        {
            //arrange
            var mockchecker = Substitute.For<IRoomsystem>();
            var booking = new BookingSystem(mockchecker);
            var startDate = new DateTime(2025, 01, 10, 0, 0, 0, DateTimeKind.Utc);
            var endDate = new DateTime(2025, 01, 10, 0, 0, 0, DateTimeKind.Utc);
            //act
            var result = await booking.BookTimeSlot(startDate, endDate);
            //assert
            Assert.IsFalse(result, " Booking should fail when start date is equal to end date");
        }

        //Test when startDate is after endDate.
        [TestMethod()]
        public async Task BookTimeSlot_ShouldReturnFalse_WhenstarDatetisAfterEndDate() 
        {
            //arrange
            var mockchecker = Substitute.For<IRoomsystem>();
            var booking = new BookingSystem(mockchecker);
            var startDate = new DateTime(2025, 01, 13, 0, 0, 0, DateTimeKind.Utc);
            var endDate = new DateTime(2025, 01, 12, 0, 0, 0, DateTimeKind.Utc);

            //act
            var result = await booking.BookTimeSlot(startDate, endDate);

            //assert
            Assert.IsFalse(result, " Booking should fail when start date is equal to end date");
        }

        //Return correct time slots  and correct number of time slots
        [TestMethod()]
        public async Task GetAvailableTimeSlots_ReturnCorrectTimeandCorrectstimeslots()
        {
            //arrange
            var mockchecker = Substitute.For<IRoomsystem>();
            var booking = new BookingSystem(mockchecker);
            booking.Bookings.Add(new Booking(new DateTime(2025, 01, 10, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 01, 12, 0, 0, 0, DateTimeKind.Utc)));
            var startDate = new DateTime(2025, 01, 10, 0, 0, 0, DateTimeKind.Utc);
            var endDate = new DateTime(2025, 01, 12, 0, 0, 0, DateTimeKind.Utc);
            //act
            var result = await booking.GetAvailableTimeSlots();
            //assert
            Assert.AreEqual(1, result.Count, "There should be one available time slot");
            Assert.AreEqual(startDate, result[0], "The available time slot should be the same as the booking");
        }

        //Return correct time slots when there are multiple bookings
        [TestMethod()]
        public async Task GetAvailableTimeSlots_ReturnCorrectTimeandCorrectstimeslots_WhenMultipleBookings()
        {
            //arrange
            var mockchecker = Substitute.For<IRoomsystem>();
            var booking = new BookingSystem(mockchecker);
            booking.Bookings.Add(new Booking(new DateTime(2025, 01, 10, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 01, 12, 0, 0, 0, DateTimeKind.Utc)));
            booking.Bookings.Add(new Booking(new DateTime(2025, 01, 13, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 01, 15, 0, 0, 0, DateTimeKind.Utc)));
            var startDate = new DateTime(2025, 01, 10, 0, 0, 0, DateTimeKind.Utc);
            var endDate = new DateTime(2025, 01, 12, 0, 0, 0, DateTimeKind.Utc);
            //act
            var result = await booking.GetAvailableTimeSlots();
            //assert
            Assert.AreEqual(2, result.Count, "There should be two available time slots");
            Assert.AreEqual(startDate, result[0], "The available time slot should be the same as the booking");
            Assert.AreEqual(new DateTime(2025, 01, 13, 0, 0, 0, DateTimeKind.Utc), result[1], "The available time slot should be the same as the booking");
        }
    }
}