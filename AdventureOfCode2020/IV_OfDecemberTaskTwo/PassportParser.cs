using System;
using System.Collections.Generic;

namespace IV_OfDecemberTaskTwo
{
    public static class PassportParser
    {
        public static IEnumerable<Passport> ParseInput(String[] inputStr)
        {
            var currPassportStr = "";
            for (var i = 0; i < inputStr.Length; i++)
            {
                var line = inputStr[i];
                currPassportStr += " " + line;
                
                if (String.IsNullOrWhiteSpace(line) || i == inputStr.Length - 1)
                {
                    var passport =new Passport(currPassportStr); 
                    currPassportStr = "";
                    yield return passport;
                }
            }
        }
    }
}