#include<iostream>
#include<algorithm>
#include<cstdio>
#include<queue>
const int INF = 100000;
const int MAX_N = 22;
using namespace std;

int n;
int cost[MAX_N][MAX_N];//最少3个点，最多MAX_N个点
int abound = 0;//上界
typedef struct {
    int x;
    int y;
}point;

point road[MAX_N];//存储最短路径

//计算当前矩阵的bound值
int calBound(int bound,int cost[MAX_N][MAX_N]) {
    int mincolumn = INF;
    for (int i = 1; i <= n; i++)
    {
        mincolumn = INF;
        for (int j = 1; j <= n; j++) {
            if (cost[i][j] < mincolumn) {
                mincolumn = cost[i][j];
            }
        }
        if(mincolumn!=0)
        {
            for (int j = 1; j <= n; j++) {
                if (cost[i][j] != INF) {
                    cost[i][j] -= mincolumn;
                }
            }
        }
        if(mincolumn!=INF)
            bound += mincolumn;
    }
    for (int j = 1; j <= n; j++)
    {
        mincolumn = INF;
        for (int i = 1; i <= n; i++) {
            if (cost[i][j] < mincolumn) {
                mincolumn = cost[i][j];
            }
        }
        for (int i = 1; i <= n; i++) {
            if (cost[i][j] != INF) {
                cost[i][j] -= mincolumn;
            }
        }
        if(mincolumn!=INF)
            bound += mincolumn;
    }
    return bound;
}
//初始化数组
void init() 
{
    cout<<"请输入城市数量：";
    cin >> n;
    cout<<"请输入路径耗费矩阵："<<endl;
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            cin >> cost[i][j];
            if (i == j)
            {
                cost[i][j] = INF;
            }
        }
    }
    abound = calBound(abound,cost);
}
//找出最短路径
void choose(int cost[MAX_N][MAX_N],int bound,int a) 
{
    if (a == 1) {
        abound = bound;
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n; j++) {
                if (cost[i][j] == 0) {
                    point temp;
                    temp.x = i;
                    temp.y = j;
                    road[1] = temp;
                }
            }
        }
        return;

    }
    int tempcost[MAX_N][MAX_N];
    int tempbound = bound;
    int maxminus = 0;
    int minus = 0;
    point minuspoint;
    for (int i = 1; i <= n; i++) 
    {
        for (int j = 1; j <= n; j++)
        {
            if (cost[i][j] == 0) 
            {
                minus = 0;
                for (int k = 1; k <= n; k++) 
                {
                    if(cost[k][j]!=INF)
                        minus += cost[k][j];
                }
                for (int l = 1; l <= n; l++) 
                {
                    if (cost[i][l] != INF)
                        minus += cost[i][l];
                }
                if (minus > maxminus) {
                    maxminus = minus;
                    minuspoint.x = i;
                    minuspoint.y = j;
                }
            }
        }
    }
    for (int i = 1; i <= n; i++) {
        for (int j = 1; j <= n; j++) {
            if (j == minuspoint.y||i == minuspoint.x) {
                tempcost[i][j] = INF;
            }else{
                tempcost[i][j] = cost[i][j];
            }
        }
    }
    tempcost[minuspoint.y][minuspoint.x] = INF;
    tempbound = calBound(bound, tempcost);
    cost[minuspoint.x][minuspoint.y] = INF;
    bound = calBound(bound, cost);
    //剪枝，通过bound判断选择路径
    if (bound > tempbound) {
        road[a].x = minuspoint.x;
        road[a].y = minuspoint.y;
        choose(tempcost, tempbound,a-1);
    }
    else {
        choose(cost, bound, a);
    }
}

void printRoad() {
    int tempY = 1;
    cout << "1";
    for (int j = 1; j <= n; j++) {
        for (int i = 1; i <= n; i++) {
            if (road[i].x == tempY) {
                cout << "->" << road[i].y;
                tempY = road[i].y;
                break;
            }
        }
        if (tempY == 1)
            return;
    }
    
}

int main() {
    init();
    choose(cost,abound,n);
    cout <<"最终的上界值为："<< abound<<endl;
    cout<<"旅行路径为：";
    printRoad();
}
/*
测试用例为书P226面的数据：（用10000代表无穷）
5
10000 17 7 35 18
9 10000 5 14 19
29 24 10000 30 12
27 21 25 10000 48
15 16 28 18 10000
其他测试用例：
5
100000 5 61 34 12
57 100000 43 20 7
39 42 100000 8 21
6 50 42 100000 8
41 26 10 35 100000
*/