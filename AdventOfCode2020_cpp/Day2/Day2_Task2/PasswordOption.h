#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <regex>
//
// Created by aublue on 05.12.20.
//

#ifndef DAY2_TASK2_PASSWORDOPTION_H
#define DAY2_TASK2_PASSWORDOPTION_H

using namespace std;

class PasswordOption {

private:
    //Specifiying Regex for parsing the input.
    const regex OccurrenceRegex = regex("([0-9]+)");
    const regex PassCharRegex = regex("([a-z]+)(?=:)");
    const regex PasswordRegex = regex("([a-z]+)(?!\\w)(?!:)");

    //Private Variables

    //Private Methods
    void _SetMinMaxOccurrence(string input);
    void _SetPassChar(string input);
    void _SetPassword(string input);
    std::vector<string> _GetAllMatches(regex reg, string inputstr);

public:
    //Public Variables
    int MinOccurrence = 0;
    int MaxOccurrence = 0;
    char PassChar = ' ';
    string Password = "";
    bool PasswordValid = false;

    //Constructors
    PasswordOption(string s);

    //Public Methods
};


#endif //DAY2_TASK1_PASSWORDOPTION_H
