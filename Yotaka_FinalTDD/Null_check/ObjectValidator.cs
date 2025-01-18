using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotaka_FinalTDD.Null_check
{
    public class ObjectValidator
    {
        public bool IsNull(object obj)
        {
            if (obj == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<string> GetNullProperties(object obj) 
        {
            throw new NotImplementedException();
        }
    }
}
