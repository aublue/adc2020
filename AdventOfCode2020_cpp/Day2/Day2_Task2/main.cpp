#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include "PasswordOption.h"

using namespace std;

void readFile(string filename, std::vector<string> &list);

int main()
{
    int validPasswordCount = 0;
    std::vector<PasswordOption*> passwordOptions;
    std::vector<string> input;
    string filename = "input.txt";

    readFile(filename, input);

    for(int i = 0; i < input.size(); i++)
    {
        PasswordOption *p = new PasswordOption(input[i]);
        passwordOptions.push_back(p);
        if(p->PasswordValid) validPasswordCount++;
    }

    cout << validPasswordCount << " valid Passwords are in the input file for day 2 task 2" << endl;
    return 0;
}

void readFile( string filename, std::vector<string> &lines)
{
    string s;
    lines.clear();
    ifstream file(filename);
    while (getline(file, s))
    {
        lines.push_back(s);
    }
}
