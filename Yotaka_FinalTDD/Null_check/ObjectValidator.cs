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
            return obj == null;
        }
        public List<string> GetNullProperties(object obj) 
        {
            ArgumentNullException.ThrowIfNull(obj); 

            List<string> nullProperties = new List<string>();
            var properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                // Check if the property value is null
                if (property.GetValue(obj) == null)
                {
                    nullProperties.Add(property.Name); // Add the property name to the list
                }
            }
            return nullProperties; // Return the list of null property names
        }
    }
}
