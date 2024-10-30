using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsValidation
    {
         public static bool IsValidEmail(string email)
         {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
         }

        public static bool IsAllLetters(string str)
        {
            foreach(char c in str) 
            {
                if (char.IsLetter(c))
                     return false;
            }
            return true;
        }

        public static bool IsAllDigits(string str)
        {
            foreach(char c in str)
            {
                if(char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public static bool IsNumber(string str)
        {
            foreach(char c in str)
            {
                if(char.IsNumber(c)) return false;
            }
            return true;
        }
        
    }
}
