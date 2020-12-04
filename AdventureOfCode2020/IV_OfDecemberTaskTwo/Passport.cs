using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace IV_OfDecemberTaskTwo
{
    public class Passport
    {
        //Key, validation function
        private static readonly Dictionary<String, Func<string, bool>> RequiredPassPortKeys =
            new Dictionary<String, Func<string, bool>>()
            {
                {"byr", s => NumberBetween(s, 1920, 2002)},
                {"iyr", s => NumberBetween(s, 2010, 2020)},
                {"eyr", s => NumberBetween(s, 2020, 2030)},
                {"hgt", HeightInRange},
                {"hcl", HairColorValid},
                {"ecl", EyeColorValid},
                {"pid", PassportIdValid}
            };

        private static readonly Regex KeyRegex = new Regex("([a-z])+(?=:)");
        private static readonly Regex ValueRegex = new Regex("(?<=:)[\\w#]+");
        private static readonly Regex HairColorRegex = new Regex("#[0-9a-f]*");
        private static readonly Regex PassPortIdRegex = new Regex("[0-9]*");
        private Dictionary<String, String> PassPortValues { get; set; }

        public bool IsValid { get; private set; }


        public Passport(String rawData)
        {
            var keys = KeyRegex.Matches(rawData).Select(x => x.Value).ToList();
            var values = ValueRegex.Matches(rawData).Select(x => x.Value).ToList();

            if (keys.Count() != values.Count()) throw new Exception("Key list length not equal value list length!");

            PassPortValues = keys.Zip(values).ToDictionary(x => x.First, v => v.Second);

            var compStr = String.Join(' ', PassPortValues.Select(x => $"{x.Key}:{x.Value}"));
            if (rawData.StartsWith(compStr)) throw new Exception("Parsing error!");

            IsValid = PassPortValid();
        }

        private bool PassPortValid()
        {
            foreach (var requiredPassPortKey in RequiredPassPortKeys)
            {
                if (!PassPortValues.TryGetValue(requiredPassPortKey.Key, out var value) || !requiredPassPortKey.Value.Invoke(value))
                {
                    return false;
                }
            }
            return true;
        }

        #region Validation Methods

        private static bool NumberBetween(string value, int minimum, int maximum)
        {
            if (Int32.TryParse(value, out var number))
            {
                return number >= minimum && number <= maximum;
            }
            else return false;
        }

        private static bool HeightInRange(String value)
        {
            var heightStr = value.Substring(0, value.Length - 2);
            if (value.EndsWith("cm"))
            {
                return NumberBetween(heightStr, 150, 193);
            }
            else
            {
                return NumberBetween(heightStr, 59, 76);
            }
        }

        private static bool EyeColorValid(String value)
        {
            return new String[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"}.Contains(value);
        }

        private static bool HairColorValid(String value)
        {
            return HairColorRegex.Match(value).Value.Length == 7;
        }

        private static bool PassportIdValid(String value)
        {
            return PassPortIdRegex.Match(value).Value.Length == 9;
        }

        #endregion
    }

    public static class ListExtension
    {
        public static bool ContainsAllElements<T>(this List<T> listA, IEnumerable<T> listB)
        {
            foreach (var el in listB)
            {
                if (!listA.Contains(el)) return false;
            }

            return true;
        }
    }
}