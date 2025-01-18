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
        public List<Booking> Bookings { get; private set; } = new();
        private readonly IRoomsystem _roomsystem;
        public BookingSystem(IRoomsystem roomsystem)
        {
            _roomsystem = roomsystem;
        }

        public async Task<bool> BookTimeSlot(DateTime startDate, DateTime endDate)
        {
            
            if (startDate >= endDate)
            {
                return false;
            }
            //check if the new time overlaps with any exiting bookings
            // If the new time is not completely before or after an existing booking, it overlaps.
            foreach (var booking in Bookings)
            {
                
                if (!(endDate <= booking.Starttime || startDate >= booking.Endtime))
                {
                    return false;
                }
            }
            Bookings.Add(new Booking(startDate, endDate));
            return await _roomsystem.BookTimeSlot(startDate, endDate); 
        }

        public async Task<List<DateTime>> GetAvailableTimeSlots()
        {
            return await Task.FromResult(Bookings.Select(booking => booking.Starttime).ToList()); // return all the start times of the bookings(mock data)
        }
    }
}
