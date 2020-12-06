#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <bitset>

using namespace std;

int forestXsize, forestYsize;


void forestToArr(std::vector<string> input, vector<vector<int>> *output);
void readFile(string filename, std::vector<string> &list);

int main() {
    vector<string> input;
    string filename = "input.txt";

    readFile(filename, input);

    forestXsize = input[0].size();
    forestYsize = input.size();

    vector<vector<int>> forest;

    forestToArr(input, &forest);


    int treePosition = 0, treeCount = 0;

    for(int line = 1; line < forest.size(); line++)
    {
        //Utilizing the mod function to return to stretch the input array infinitely on the x axis
        treePosition = (treePosition + 3) % forest[0].size();
        treeCount += forest[line][treePosition]; //1 = tree, 0 = freespace, so it's a simple addition.
    }


    std::cout << "Tree count: "<< treeCount << std::endl;
    return 0;
}

void forestToArr(vector<string> input, vector<vector<int>> *output)
{
    for(int l = 0; l < input.size(); l++) {
        vector<int> currentLine;

        for(int c = 0; c < input[l].size(); c++)
        {
            currentLine.push_back(input[l][c] == '.' ? 0 : 1);
        }

        (*output).push_back(currentLine);
    }
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

