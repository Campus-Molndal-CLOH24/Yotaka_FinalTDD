using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yotaka_FinalTDD.Booksystem.Interface;


namespace Yotaka_FinalTDD.Booksystem
{
    public class BookingSystem : IRoomsystem
    {
        // A list to keep track of all the bookings.
        public List<Booking> Bookings { get; private set; } = new();
        private readonly IRoomsystem _roomsystem;
        public BookingSystem(IRoomsystem roomsystem)
        {
            _roomsystem = roomsystem;
        }

        public async Task<bool> BookTimeSlot(DateTime startDate, DateTime endDate)
        {
            //check if the new booking is valid (start time is before end time)
            if (startDate >= endDate)
            {
                return false;
            }
            //check if the new time overlaps with any exiting bookings
            foreach (var booking in Bookings)
            {
                // If the new time is not completely before or after an existing booking, it overlaps.
                if (!(endDate <= booking.Starttime || startDate >= booking.Endtime))
                {
                    return false;
                }
            }
            //if no overlap, add the new booking
            Bookings.Add(new Booking(startDate, endDate));
            // Call the BookTimeSlot method on the _roomsystem mock changed from return true to return await _roomsystem.BookTimeSlot(startDate, Endtime) becuase mock data is not being used
            return await _roomsystem.BookTimeSlot(startDate, endDate); 
        }

        public async Task<List<DateTime>> GetAvailableTimeSlots()
        {
            return await Task.FromResult(Bookings.Select(booking => booking.Starttime).ToList()); // return all the start times of the bookings(mock data)
        }
    }
}
