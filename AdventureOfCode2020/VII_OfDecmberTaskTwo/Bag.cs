using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace VII_OfDecemberTaskTwo
{
    public class Bag
    {
        private static readonly Regex BagSelectorRegex = new Regex("(\\w* \\w*)(?= bag)");
        private static readonly Regex BagAmountRegex = new Regex("[0-9]*");

        public String BagColor { get; set; }
        public Dictionary<String, int> ContainingBags { get; set; } = new Dictionary<String, int>();

        public Bag(String inputStr)
        {
            var Numbers = BagAmountRegex.Matches(inputStr)
                .Where(x => !String.IsNullOrWhiteSpace(x.Value))
                .Select(x => Int32.Parse(x.Value)).ToArray();
            var Names = BagSelectorRegex.Matches(inputStr).Select(x => x.Value).ToList();

            BagColor = Names[0];
            Names = Names.Where(x => x != Names.First()).ToList();

            ContainingBags = Names.Zip(Numbers).ToDictionary(k => k.First, v => v.Second);
        }
    }
}