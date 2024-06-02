using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SANYUKT.Commonlib.Security
{
    public class CommonHelper
    {
        public bool isValidPan(string panNumber)
        {
            bool result = false;
            Regex regex = new Regex("([A-Z]){5}([0-9]){4}([A-Z]){1}$");

            result = regex.IsMatch(panNumber);

            return result;
        }

        public bool isValidEmail(string eMail)
        {
            bool result = false;
            Regex emailregex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            result = emailregex.IsMatch(eMail);

            return result;
        }

        public bool isValidMobile(string Mobile)
        {
            bool result = false;
            Regex reg = new Regex(@"^[0-9]{10}$");

            result = reg.IsMatch(Mobile);

            return result;
        }

        public static string EnsureNotNull(object value)
        {
            if (value == null)
                return string.Empty;

            return value.ToString();
        }

        public static string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }
    }
}
