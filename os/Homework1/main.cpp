//
//  main.cpp
//  Homework1
//
//  Created by 邢宸亮 on 2021/7/7.
//

#include <iostream>
using namespace std;

struct Process
{
    int name;   //进程名
    int priority;   //优先级
    int time;   //运行时间
    char status;    //运行状态
    Process *next;  //指针
};

int con = 5;
    
//按照进程的优先级从高到低对进程进行排序，运用插入排序
void sort(Process *&pcbHead) {
    if(pcbHead == NULL || pcbHead->next == NULL) return;
    Process *p = pcbHead->next, *pstart = (Process*)malloc(sizeof(Process)), *pend = pcbHead;
    pstart->next = pcbHead;     //为了操作方便，添加一个头结点
    while(p!= NULL)
    {
        Process *tmp = pstart->next, *pre = pstart;
        while(tmp != p && p->priority <= tmp->priority) //找到插入位置
        {
            tmp = tmp->next; pre = pre->next;}
            if(tmp == p)    pend = p;
            else
            {
                pend->next = p->next;
                p->next = tmp;
                pre->next = p;
            }
            p = pend->next;
        }
        pcbHead = pstart->next;
}

void outPut(Process *pcbHead) {
    if(pcbHead == NULL || pcbHead->next == NULL) return;
    Process *pre;
    pre = pcbHead->next;
    cout << "正在运行：" << endl;
    cout << "进程：" << pcbHead->name <<" "<< "优先数：" << pcbHead->priority <<" "<< "剩余时间：" << pcbHead->time << endl;
    cout << "就绪队列：" << endl;
    while (pre!=NULL) {
        if(pre->status == 'R'){
            cout << "进程：" << pre->name <<" "<< "优先数：" << pre->priority <<" "<< "剩余时间：" << pre->time << endl;
        }
        pre = pre->next;
    }
    cout<<endl;
}

int main()
{
    Process *pcbHead;
    Process *pre;
    pcbHead = (Process *)malloc(sizeof(Process));
    pre = pcbHead;
    string str;
    int i = 1;
    //创建五个进程
    while (i <= 5) {
        pre->next = (Process *)malloc(sizeof(Process));
        pre->name = i;
        pre->status = 'R';
        pre = pre->next;
        i++;
    }
    //用户输入进程优先数和运行时间
    pre = pcbHead;
    cout << "请依次输入五个进程的优先数和运行时间：" << endl;
    while (pre->name) {
        cin >> str;
        pre->priority = atoi(str.c_str());
        cin >> str;
        pre->time = atoi(str.c_str());
        pre = pre->next;
    }

    sort(pcbHead);

    do {
        if (pcbHead->time > 0) {
            outPut(pcbHead);
            pcbHead->priority--;
            pcbHead->time--;
        }
        if (pcbHead->time == 0) {
            pcbHead->status = 'E';
            pcbHead = pcbHead->next;
        }
        sort(pcbHead);
    } while (pcbHead);

    cout << "所有进程执行完成";
}

/*
 5 5

 4 4

 3 3

 2 2

 1 1
 */
