using NSubstitute.Routing.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotaka_FinalTDD.Booksystem
{
    public class BookingServiceFacade
    {
        private readonly BookingSystem _bookingSystem;
        public BookingServiceFacade(BookingSystem bookingSystem)
         {
            _bookingSystem = bookingSystem;
         }
        public async Task<bool> BookSlot( DateTime startDate, DateTime endDate)
        {
            if (startDate == default(DateTime))
            {
                throw new ArgumentException("Date cannot be null");
            }
            return await _bookingSystem.BookTimeSlot( startDate, endDate);  
        }
    }
    
}
