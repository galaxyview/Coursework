#include <iostream>
#include<string>
using namespace std;

typedef struct freeArea {
    int startAddress;    //起始地址
    int length;     //所占空间长度
    freeArea* next;     //地址指针
};

typedef struct occupyArea {
    int startAddress;     //起始地址
    int length;     //所占空间长度
    string ProcessName;
    occupyArea* next;   //地址指针
};

//删除空闲区域表中长度为零的区域
void simplify(freeArea *fHead){
    freeArea *p = fHead->next;
    freeArea *pre = fHead;
    while(p){
        if(p->length==0)
        pre->next = p->next; 
        p = p->next;
        pre = pre->next;
    }
}

void occupy(occupyArea* o,freeArea* fHead,int length,string ProcessName){
    freeArea *p = fHead->next;
    freeArea *pre = fHead;
    occupyArea *q = o;

    while (p != NULL) {
        if (p->length >= length) {
            occupyArea* o1 = (occupyArea*)malloc(sizeof(occupyArea));
            o1->length = length;
            o1->ProcessName = ProcessName;
            o1->startAddress = p->startAddress;
            o1->next = q->next;
            q->next = o1;
            p->startAddress = p->startAddress + length;
            p->length = p->length - length;
            simplify(fHead);
            return;
        }
        p = p->next;
    }
    
    cout << "空间不足" << endl;
}

void mergeAndInsert(freeArea *fHead, int startAddress, int length){
    freeArea *p = fHead->next;
    freeArea *q = (freeArea*)malloc(sizeof(freeArea));
    q->startAddress = startAddress;
    q->length = length;

    while (p)
    {
        //若需要释放的空间刚好与第一个空闲区相接
        if(q->startAddress + q->length == p->startAddress){
            p->length = p->length + q->length;
            p->startAddress = q->startAddress;
            return;
        }

        //若需要释放的空间的结束位置在第一个空闲区之前
        if(q->startAddress + q->length < p->startAddress){
            q->next = p;
            fHead->next = q;
            return;
        }

        //若需要释放的空间在第一个空闲区之后
        if(p->startAddress < q->startAddress){
            //若需要释放的空间的起始位置刚好在第一个空闲区结束的位置
            if(p->startAddress + p->length == q->startAddress){
                p->length = p->length + q->length;
                //若需要释放的空间与前一个空闲区合并之后刚好与后一个空闲区相接
                if(p->next && p->next->startAddress == p->startAddress + p->length){
                    p->length = p->length + p->next->length;
                    p->next = p->next->next;
                }
                return;
            }

            //若p后没有其他空闲区，则直接将释放的空闲区接到p后
            if(!p->next){
                p->next = q;
                q->next = NULL;
                return;
            }else{
                //若p后的空闲区的起始地址刚好等于释放空间的结尾，则将两者合并
                if(q->startAddress + q->length == p->next->startAddress){
                    p->next->length = p->next->length + q->length;
                    p->next->startAddress = q->startAddress;
                }else{
                    q->next = p->next;
                    p->next = q;
                }
                return;
            }
        }
        p = p->next;
    }
}

void release(occupyArea* o, freeArea* fHead,string ProcessName){
    freeArea *p = fHead->next;
    occupyArea *q = (occupyArea*)malloc(sizeof(occupyArea));
    q->next = o;
    occupyArea *r = o;

    while(r){
        if(r->ProcessName == ProcessName){
            mergeAndInsert(fHead,r->startAddress,r->length);
            q->next = r->next;
            cout<<"进程所占用的存储空间已释放！"<<endl;
            return;
        }
        q = q->next;
        r = r->next;
    }
    cout<<"该进程不存在！"<<endl;
}

void display(freeArea *fHead, occupyArea *o){
    freeArea *p = fHead->next;
    occupyArea *q = o;
    int i = 1;
    int j = 0;

    cout<<endl;
    cout<<"空闲区域表："<<endl;
    cout << "--------------------------" << endl;
    cout << "空闲分区号  起始地址  长度" << endl;
    cout << "--------------------------" << endl;
    while(p){
        cout << i << "             " << p->startAddress << "      " << p->length << endl;
        p = p->next;
        i++;
    }
    cout<<endl;
    cout<<"进程空间分配表："<<endl;
    cout << "------------------------" << endl;
    cout << "进程编号  起始地址  长度" << endl;
    cout << "------------------------" << endl;
    while (q)
    {
        if(j)
            cout << q->ProcessName << "             " << q->startAddress << "       " << q->length << endl;
        q = q->next;
        j++;
    }
}

int main(){
    //初始化空闲区域表
    freeArea *fHead = (freeArea*)malloc(sizeof(freeArea));
    fHead->next = (freeArea*)malloc(sizeof(freeArea));
    fHead->next->startAddress = 0;
    fHead->next->length = 128;
    fHead->next->next = NULL;

    //初始化已分配空间表
    occupyArea *o = (occupyArea*)malloc(sizeof(occupyArea));

    int op;
    string ProcessName;
    int length;

    while (1)
    {
        cout<<endl;
        cout<<"请输入操作对应的序号："<<endl;
        cout<<"1.分配空间"<<endl;
        cout<<"2.释放空间"<<endl;
        cout<<"0.退出程序"<<endl;
        cin>>op;
        switch (op)
        {
        case 1:
            cout << "请依次输入进程名和空间大小：" << endl;
            cin >> ProcessName;
            cin >> length;
            occupy(o, fHead, length, ProcessName);
            display(fHead,o);
            break;
        case 2:
            cout << "请输入要释放的进程名：" << endl;
            cin >> ProcessName;
            release(o,fHead,ProcessName);
            display(fHead,o);
            break;
        case 0:
            return 0;
        default:
            break;
        }
    }     
}