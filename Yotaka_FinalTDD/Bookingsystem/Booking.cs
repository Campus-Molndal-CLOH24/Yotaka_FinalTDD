using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotaka_FinalTDD.Booksystem
{
    public class Booking
    {
        
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }

        public Booking( DateTime starttime, DateTime endtime)
        {
            
            Starttime = starttime;
            Endtime = endtime;
        }
    }
}
