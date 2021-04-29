using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask
{
    public class Validator
    {
        public static bool ConvertTo(string input, out int result)
        {
            return Int32.TryParse(input, out result);
        }
        public static bool ConvertTo(string input)
        {
            return input == String.Empty;
        }
    }
}
