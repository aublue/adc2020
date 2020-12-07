using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VII_OfDecemberTaskOne
{
    public class Bag
    {
        private static readonly Regex BagSelectorRegex = new Regex("(\\w* \\w*)(?= bag)");

        public String BagColor { get; set; }
        public List<String> ContainingBags { get; set; } = new List<String>();

        public Bag(String inputStr)
        {
            foreach (Match match in BagSelectorRegex.Matches(inputStr))
            {
                if (match.Value.Contains("no other"))
                {
                    continue;
                }
                
                if (String.IsNullOrWhiteSpace(BagColor))
                {
                    BagColor = match.Value;
                }
                else
                {
                    ContainingBags.Add(match.Value);
                }
            }
        }
    }
}