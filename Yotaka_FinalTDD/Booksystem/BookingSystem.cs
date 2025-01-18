using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotaka_FinalTDD.Booksystem
{
    public List<Booking> Bookings { get; set; } // List of bookings

    public class BookingSystem
    {
        public async Task<bool> BookRoomAsync(string roomName, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
        public List<DateTime> GetAvailableTimeSlots()
        {
            throw new NotImplementedException();
        }
    }
}
