using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace IV_OfDecemberTaskOne
{
    public class Passport
    {

        private static readonly List<String> RequiredPassPortKeys = new List<string>()
            {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};

        private static readonly Regex KeyRegex = new Regex("([a-z])+(?=:)");
        private List<String> PassportKeys { get; set; }

        public bool IsValid { get; private set; }


        public Passport(String rawData)
        {
            PassportKeys = KeyRegex.Matches(rawData).Select(x => x.Value).ToList();
            IsValid = PassPortValid();
        }

        private bool PassPortValid()
        {
            return PassportKeys.ContainsAllElements(RequiredPassPortKeys);
        }
    }

    public static class ListExtension
    {
        public static bool ContainsAllElements<T>(this List<T> listA, List<T> listB)
        {
            foreach (var el in listB)
            {
                if (!listA.Contains(el)) return false;
            }

            return true;
        }
    }
}