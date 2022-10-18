// test13.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>

#include <iostream>

#define resourceNum 3
#define processNum 5

using namespace std;

int avaliable[resourceNum] = { 3,3,2 };   //可用资源向量
int request[resourceNum];   //资源请求向量
int allocation[processNum][resourceNum] = { {0,1,0},{2,0,0},{3,0,2},{2,1,1},{0,0,2} };    //分配矩阵
int need[processNum][resourceNum] = { {7,4,3},{1,2,2},{6,0,0},{0,1,1},{4,3,1} };   //需求矩阵
int maxRequest[processNum][resourceNum] = { {7,5,3},{3,2,2},{9,0,2},{2,2,2},{4,3,3} };  //最大需求矩阵
bool finish[processNum];    //进程是否完成


bool isSafe() {
    int temp_avaliable[resourceNum];    //预分配时不改变avaliable向量
    int temp_finish = 0; //在当前轮次的检查中，暂时完成的进程数
    int finishNum = 0;  //已完成的进程数
    bool isFinish = true;
    int k = 0;  //计数变量，用于遍历所有进程
    int safeSeries[processNum]; //安全序列
    int safei = 0;  //用于安全序列的计数

    //复制available数组
    for (int i = 0;i < resourceNum;i++) {
        temp_avaliable[i] = avaliable[i];
    }

    //初始化finish数组，记录已完成的进程finishnum
    for (int i = 0; i < processNum; i++) {
        isFinish = true;
        for (int j = 0;j < resourceNum;j++) {
            if (need[i][j] != 0) {
                isFinish = false;
            }
        }
        if (isFinish == true) {
            finish[i] = true;
            finishNum++;
        }
        else {
            finish[i] = false;
        }
    }

    //循环检查并生成安全队列
    while (finishNum != processNum)
    {
        
        if (!finish[k])
        {
            isFinish = true;
            for (int i = 0; i < resourceNum; i++)
            {
                if (need[k][i] > temp_avaliable[i]) {
                    isFinish = false;
                }
            }

            if (isFinish) {
                //释放资源
                for (int i = 0; i < resourceNum; i++)
                {
                    temp_avaliable[i] = temp_avaliable[i] + allocation[k][i];
                }
                finishNum++;
                safeSeries[safei] = k;
                safei++;
                finish[k] = true;
            }
        }
        
        k++;
        //当前轮次检查完所有进程之后，若没有任何可以结束的进程，则说明不安全或已检查完，否则进入下一轮检查
        if (k >= processNum)
        {
            k = k % processNum;
            if (temp_finish == finishNum)
            {
                break;
            }
            temp_finish = finishNum;
        }
    }

    for (int i = 0;i < processNum;i++) {
        if (!finish[i]) {
            cout << "当前系统不安全！" << endl;
            return false;
        }
    }

    for (int i = 0;i < processNum;i++) {
        isFinish = true;
        for (int j = 0;j < resourceNum;j++) {
            if (need[i][j] != 0) {
                isFinish = false;
            }
            if (isFinish)    finishNum--;
        }
    }

    cout << "当前系统安全！";
    /*
    for (int i = 0; i < finishNum; i++)
    {
        cout << safeSeries[i];
    }
    */
    return true;
}

void display() {
    cout << "-----------------------------------------------------------------------" << endl;
    cout << "当前系统剩余资源：";
    for (int i = 0;i < resourceNum;i++) {
        cout << avaliable[i] << " ";
    }
    cout << endl;
    cout << "当前系统资源分配情况：" << endl;
    cout << "----------------------------------------------------" << endl;
    cout << "进程号\t 最大需求\t 已分配\t\t 需求" << endl;
    cout << "----------------------------------------------------" << endl;
    for (int i = 0;i < processNum;i++) {
        cout << i << "\t";
        for (int j = 0; j < resourceNum; j++)
        {
            cout << maxRequest[i][j] << " ";
        }
        cout << "\t\t";
        for (int j = 0; j < resourceNum; j++)
        {
            cout << allocation[i][j] << " ";
        }
        cout << "\t\t";
        for (int j = 0; j < resourceNum; j++)
        {
            cout << need[i][j] << " ";
        }
        cout << endl;
    }
}

int initFinish(){
    bool isFinish;
    int finishNum = 0;
    for (int i = 0; i < processNum; i++) {
        isFinish = true;
        for (int j = 0;j < resourceNum;j++) {
            if (need[i][j] != 0) {
                isFinish = false;
            }
        }
        if (isFinish == true) {
            finish[i] = true;
            finishNum++;
        }else {
            finish[i] = false;
        }
    }
    return finishNum;
}

int main() {
    int op, a;
    int temp_allocate[resourceNum];
    bool isFinish;
    display();
    while (isSafe()) {
        /*
        for (int i = 0; i < processNum; i++) {
            isFinish = true;
            for (int j = 0;j < resourceNum;j++) {
                if (need[i][j] != 0) {
                    isFinish = false;
                }
            }
            if (isFinish == true) {
                finish[i] = true;
                finishNum++;
            }else {
                finish[i] = false;
            }
        }
        if(finishNum==processNum){
            cout<<"所有进程已完成！"<<endl;
            return 0;
        }
        */

        cout << "请输入要分配资源的进程号：";
        cin >> op;
        cout << endl;
        
        
        if(initFinish()==processNum){
            cout<<"所有进程已完成！"<<endl;
            return 0;
        }
        
        //为进程号为op的进程分配资源
        if (!finish[op]&&op<processNum) {
            for (int i = 0;i < resourceNum;i++) {
                cout << "请输入要分配的第" << i + 1 << "类资源数" << endl;
                cin >> temp_allocate[i];
                while (1) 
                {
                    if (temp_allocate[i] <= need[op][i] && temp_allocate[i] <= avaliable[i]) {
                        avaliable[i] -= temp_allocate[i];
                        allocation[op][i] += temp_allocate[i];
                        need[op][i] -= temp_allocate[i];
                        break;
                    }
                    cout << "请输入要分配的第" << i + 1 << "类资源数" << endl;
                    cin >>temp_allocate[i];
                }
            }
            isFinish = true;
            for (int i = 0;i < resourceNum;i++) {
                if (need[op][i] > 0) {
                    isFinish = false;
                }
            }
            if (isFinish) {
                //释放已完成资源
                for (int i = 0; i < resourceNum; i++) {
                    avaliable[i] = avaliable[i] + allocation[op][i];
                }
                cout << "进程" << op << "已完成,该进程占用资源已释放" << endl;
            }
            else {
                cout << "进程" << op << "未完成" << endl;
            }
            display();
            //如果分配后进入不安全状态，则将刚才的操作撤销
            if (!isSafe()) {
                for (int i = 0;i < resourceNum;i++) {
                    avaliable[i] += temp_allocate[i];
                    allocation[op][i] -= temp_allocate[i];
                    need[op][i] += temp_allocate[i];
                }
                cout << "分配失败，请重试。" << endl;
                display();
            }
        }
        else
        {
            cout << "当前进程已完成或不存在！" << endl;
        }
        
        
    }
}