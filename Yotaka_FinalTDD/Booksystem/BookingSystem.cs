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

        public async Task<bool> BookTimeSlot(DateTime startDate, DateTime Endtime)
        {
            //check if the new booking is valid (start time is before end time)
            if (startDate >= Endtime)
            {
                return false;
            }
            //check if the new time overlaps with any exiting bookings
            foreach (var booking in Bookings)
            {
                // If the new time is not completely before or after an existing booking, it overlaps.
                if (!(Endtime <= booking.Starttime || startDate >= booking.Endtime))
                {
                    return false;
                }
            }
            //if no overlap, add the new booking
            Bookings.Add(new Booking(startDate, Endtime));
            return true;
        }

        public async Task<List<DateTime>> GetAvailableTimeSlots()
        {
            return await Task.FromResult(Bookings.Select(booking => booking.Starttime).ToList()); // return all the start times of the bookings(moch data)
        }
    }
}
