using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Yotaka_FinalTDD.StringHandling
{
    public class StringProcessor
    {
        public string ToLowerCase(string input)
        {
            return input.ToLower();
        }
        public string Sanitize(string input)
        {
            return Regex.Replace(input, "[^a-zA-Z0-9]", "");
        }
        public bool AreEqual(string input1, string input2)
        {
            string input1Sanitized = Sanitize(input1);
            string input2Sanitized = Sanitize(input2);
            return input1Sanitized.Equals(input2Sanitized, StringComparison.OrdinalIgnoreCase);
        }
        

    }
}
