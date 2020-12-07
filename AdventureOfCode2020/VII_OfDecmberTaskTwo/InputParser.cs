using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VII_OfDecemberTaskTwo
{
    public static class InputParser
    {
        

        public static IEnumerable<Bag> ParseInput(IEnumerable<String> input)
        {
            foreach (var item in input)
            {
                yield return new Bag(item);
            }
        }
        
    }
}