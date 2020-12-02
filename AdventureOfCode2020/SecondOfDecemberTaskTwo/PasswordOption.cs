using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SecondOfDecemberTaskTwo
{
    public class PasswordOption
    {
        //static regex objects to prevent compiling the regex patterns multiple times
       // private static readonly Regex OccurrenceRegex = new Regex(@"([0-9]+)(?=-)");
        private static readonly Regex OccurrenceRegex = new Regex(@"([0-9]+)");
        private static readonly Regex PassCharRegex = new Regex(@"([a-z]+)(?=:)");
        private static readonly Regex PasswordRegex = new Regex(@"([a-z]+)(?!\\w)(?!:)");
        
        public int MinOccurrence { get; private set; }
        public int MaxOccurrence { get; private set; }
        public char PassChar { get; private set; }
        public String Password { get; private set; }
        public int PassCharCount { get; private set; }
        public bool PasswordValid { get; private set; }

        public PasswordOption(String PassLine)
        {
            SetMinMaxOccurrence(PassLine);
            SetPassChar(PassLine);
            SetPassword(PassLine);

            if ((MinOccurrence + "-" + MaxOccurrence + " " + PassChar + ": " + Password) != PassLine)
            {
                throw new Exception("Parsing error");
            }
            
            PasswordValid = (Password[MinOccurrence - 1] == PassChar && Password[MaxOccurrence - 1] != PassChar) ||
                            (Password[MinOccurrence - 1] != PassChar && Password[MaxOccurrence - 1] == PassChar);
        }

        private void SetMinMaxOccurrence(String input)
        {
            var minOutput = OccurrenceRegex.Matches(input)[0].Value;
            var maxOutput = OccurrenceRegex.Matches(input)[1].Value;
            MinOccurrence = Int32.Parse(minOutput);
            MaxOccurrence = Int32.Parse(maxOutput);
        }

        private void SetPassChar(String input)
        {
            var output = PassCharRegex.Match(input).Value;
            PassChar = char.Parse(output);
        }

        private void SetPassword(String input)
        {
            var output = PasswordRegex.Match(input).Value;
            Password = output;
        }
    }
}