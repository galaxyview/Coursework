#include<stdio.h>
#define N 7 //作业数
#define M 3 //机器数 
int s[M] = {0,0,0};//每台机器当前已分配的作业总耗时 

//求出目前处理作业的时间和 最小的机器号
int min(int m)
{
    int min = 0;
    int i;
    for(i=1;i<m;i++)
    {
        if(s[min] > s[i])
        {
           min = i;
        }
    }
    return min;
}

//求最终结果（最长处理时间）
int max(int s[],int num)
{
    int max = s[0];
    int i;
    for(i=1;i<num;i++)
    {
        if(max < s[i])
        {
           max = s[i];
        }
    }   
    return max;
}
 
//机器数小于待分配作业数 
int setwork(int t[],int num[],int n)
{
    int i;
    int mi = 0;
    for(i=0;i<n;i++)
    {
      mi = min(M);
      printf("%d号作业,分配第%d号机器\n",num[i],mi);
      s[mi] = s[mi]+t[i];
    }
    int ma = max(s,M);
    return ma;
}
//将作业时间由大到小排序
void sort(int time[],int num[],int n)
{
    int max = 0;
    int maxj = 0;
    int temp = 0;
    for(int i = 0;i<n;i++){
        max = 0;
        maxj = 0;
        for (int j = i; j < n; j++)
        {
            if (time[j]>max)
            {
                max = time[j];
                maxj = j;
            } 
        }
        time[maxj] = time[i];
        time[i] = max;
        temp = num[maxj];
        num[maxj] = num[i];
        num[i] = temp;
    }
}

int main(void) 
{
    int time[N] = {2,14,4,6,16,5,3};//处理时间按从大到小排序 
    int number[N] = {0,1,2,3,4,5,6};
    sort(time,number,N);
    int maxtime = 0;
    maxtime = setwork(time,number,N); 
    printf("最多耗费时间%d。",maxtime);
}
 
 


 


