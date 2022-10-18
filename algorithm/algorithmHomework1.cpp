#include <iostream>
using namespace std;

const int N = 8;
int arr[N + 1] = { 0,-1,2,5,4,-7,6,8,-2 };

int maxSection(int arr[N + 1], int low, int high)
{
    int maxSum = 0;
    if (high == low)
    {
        if (arr[low] <= 0)
            maxSum = 0;
        else
            maxSum = arr[low];
    }
    else
    {
        int mid = (high + low) / 2;
        int leftSum = maxSection(arr, low, mid);    //左侧部分的最大子段和
        int rightSum = maxSection(arr, mid + 1, high);  //右侧部分的最大子段和
        int s1 = 0;
        int s2 = 0;
        int leftTempSum = 0;    //当最大子段在两侧时，左侧子段暂时累加的值
        int rightTempSum = 0;   //当最大子段在两侧时，右侧子段暂时累加的值
        
        //最大子段在两侧时的最大子段和为maxSum
        for (int i = mid; i >= low; i--) {
            leftTempSum += arr[i];
            if (leftTempSum > s1) {
                s1 = leftTempSum;
            }
        }
        for (int i = mid + 1; i <= high; i++) {
            rightTempSum += arr[i];
            if (rightTempSum > s2) {
                s2 = rightTempSum;
            }
        }
        maxSum = s1 + s2;

        if (maxSum < leftSum) {
            maxSum = leftSum;
        }
        if (maxSum < rightSum) {
            maxSum = rightSum;
        }
    }
    return maxSum;
}

int main()
{
    int sum = maxSection(arr, 1, N);
    cout <<"最大子段和为：" << sum << endl;
    return 0;
}