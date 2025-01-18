using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotaka_FinalTDD.Booksystem.Interface
{
    public interface IRoomsystem
    {
        Task<bool> BookTimeSlot(DateTime startDate, DateTime endDate);
        Task<List<DateTime>> GetAvailableTimeSlots();
    }
}
