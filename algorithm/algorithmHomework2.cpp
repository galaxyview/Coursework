#include <iostream>
#include <stdio.h>
#include <string>
#include <algorithm>

using namespace std;

const int n = 10;
const int m = 12;

string A = " xyxxzxyzxy";
string B = " zxzyyzxxyxxz";
string Z = "";
int L[n + 1][m + 1];
int maxLen = 0;

int main()
{
    for (int i = 0; i < n + 1; i++)
    {
        L[i][0] = 0;
    }
    for (int j = 0; j < m + 1; j++)
    {
        L[0][j] = 0;
    }
    for (int i = 1; i < n + 1; i++)
    {
        for (int j = 1; j < m + 1; j++)
        {
            if (A[i] == B[j])
            {
                L[i][j] = L[i - 1][j - 1] + 1;
            }
            else {
                L[i][j - 1] < L[i - 1][j] ? L[i][j] = L[i - 1][j] : L[i][j] = L[i][j - 1];
            }
        }
    }
    int i = 10;
    int j = 12;
    

    while (true)
    {
        if (A[i]!=B[j])
        {
            if (L[i][j] == L[i - 1][j]) 
                i--;       
            else if (L[i][j] == L[i][j - 1])
                j--;
        }
        else
        {
            string x = string(1, A[i]);
            Z = Z.append(x);
            i--;
            j--;
        }
        if (i == 0 || j == 0) {
            reverse(Z.begin(), Z.end());
            cout << "最长公共子序列长度为"<< L[n][m] << endl;
            cout << "最长公共子序列为：" << Z;
            return 0;
        }

    }

    

}