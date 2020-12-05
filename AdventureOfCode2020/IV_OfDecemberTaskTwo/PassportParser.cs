using System;
using System.Collections.Generic;
using System.Linq;

namespace IV_OfDecemberTaskTwo
{
    public static class PassportParser
    {
        public static IEnumerable<Passport> ParseInput(String[] inputStr)
        {
            var passportStrings = new List<String>();
            
            var currPassportStr = "";
            for (var i = 0; i < inputStr.Length; i++)
            {
                var line = inputStr[i];
                currPassportStr += " " + line;
                
                if (String.IsNullOrWhiteSpace(line) || i == inputStr.Length - 1)
                {
                    passportStrings.Add(currPassportStr);
                    currPassportStr = "";
                }
            }

            return passportStrings.Select(x => new Passport(x));
        }
    }
}