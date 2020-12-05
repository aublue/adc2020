#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <regex>
//
// Created by aublue on 05.12.20.
//

#include "PasswordOption.h"

PasswordOption::PasswordOption(string s) {
    _SetMinMaxOccurrence(s);
    _SetPassChar(s);
    _SetPassword(s);

    this->PassCharCount = std::count(this->Password.begin(), this->Password.end(), this->PassChar);
    this->PasswordValid = (this->MinOccurrence <= this->PassCharCount && this->PassCharCount <= this->MaxOccurrence);
}

void PasswordOption::_SetMinMaxOccurrence(string input) {

    vector<string> matches = _GetAllMatches(this->OccurrenceRegex, input);

    if(matches.size() == 2)
    {
        string min = matches[0];
        string max = matches[1];

        this->MinOccurrence = stoi(min);
        this->MaxOccurrence = stoi(max);
    }else{
        throw "Error while parsing input line: " + input;
    }
}

void PasswordOption::_SetPassChar(string input)
{
    vector<string> matches = _GetAllMatches(this->PassCharRegex, input);

    if(matches.size() == 1)
    {
        string charStr = matches[0];
        this->PassChar = charStr[0];
    }else{
        throw "Error while parsing input line: " + input;
    }
}

void PasswordOption::_SetPassword(string input)
{
    vector<string> matches = _GetAllMatches(this->PasswordRegex, input);

    if(matches.size() == 1)
    {
        this->Password = matches[0];
    }else{
        throw "Error while parsing input line: " + input;
    }
}

std::vector<string> PasswordOption::_GetAllMatches(regex reg, string inputstr)
{
    vector<string> output;
    smatch regExMatch;

    string::const_iterator searchStart (inputstr.cbegin());
    while(regex_search(searchStart, inputstr.cend(), regExMatch, reg))
    {
        output.push_back(regExMatch[0]);
        searchStart = regExMatch.suffix().first;
    }
    return output;
}