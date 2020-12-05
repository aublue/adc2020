#include <iostream>
#include <fstream>
#include <vector>
#include <string>

using namespace std;

int getTwentyTwentyProduct(std::vector<int> &input);
void readFile(string filename, std::vector<int> &list);

int main() {

    std::vector<int> input;
    string filename = "input.txt";

    readFile(filename, input);

    std::cout << "Result: " << getTwentyTwentyProduct(input) << endl;

    return 0;
}

int getTwentyTwentyProduct(std::vector<int> &input)
{
    int inputSize = input.size();
    for(int i = 0; i < inputSize; i++)
    {
        for(int j = 0; j < inputSize; j++)
        {
            if(input[i] + input[j] == 2020)
            {
                return input[i] * input[j];
            }
        }
    };
    return -1;
}

void readFile( string filename, std::vector<int> &lines)
{
    string s;
    lines.clear();
    ifstream file(filename);
    while (getline(file, s))
    {
        int intVal = std::stoi(s);
        lines.push_back(intVal);
    }
}
