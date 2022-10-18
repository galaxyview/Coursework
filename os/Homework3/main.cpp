#include <iostream>
using namespace std;



void occupy(int disc[][8],int num,int &discLeft){
    if(num > discLeft){
        cout<<"磁盘存储空间不足，无法完成分配"<<endl;
    }
    discLeft = discLeft - num;

    int cylinderNum;    //柱面号
    int trackNum;       //磁道号
    int physicalRecord;     //物理记录号
    int i=0,j=0;    //j代表已经查找的物理记录数，i代表已分配磁盘空间的位数
    
    cout << "分配的物理地址如下表："<<endl;
    cout << "------------------------" << endl;
    cout << "柱面号 磁道号 物理记录号"<<endl;
    cout << "------------------------" << endl;
    
    while (i<num)
    {
        if(disc[j/8][j%8] == 0){
            cylinderNum = j/8;
            trackNum = (j%8) / 4;
            physicalRecord = (j%8) % 4;
            disc[j/8][j%8] = 1;
            cout << cylinderNum<<"         "<<trackNum<<"          "<<physicalRecord<<endl;
            i++;
        }
        j++;
    }
}

void release(int disc[][8],int cylinderNum,int trackNum,int physicalRecord,int &discLeft){
    int byteNum,bitNum;
    byteNum = cylinderNum;
    bitNum = trackNum*4 + physicalRecord;
    if(disc[byteNum][bitNum%8]==1){
        disc[byteNum][bitNum%8] = 0;
        discLeft++;
        cout<<"归还了字节号为"<<byteNum<<"位数为"<<bitNum<<"的物理块。"<<endl;
    }else{
        cout<<"该块不存在或未分配。"<<endl;
    }
    
}

void displayBitMap(int disc[][8]){
    cout<<"位视图如下"<<endl;
    for(int i = 0;i<8;i++){
        cout<<"字节"<<i;
        for(int j = 0;j<8;j++){
            cout<<" "<<disc[i][j];
        }
        cout<<endl;
    }
}

void showMenu(){
    cout << "请输入操作内容对应的序号：" << endl;
    cout << "1、申请" << endl;
    cout << "2、归还" << endl;
    cout << "0、退出" << endl;
}

int main(){
    //初始化磁盘空间
    int disc[8][8];
    int discLeft = 64;
    for (int i = 0; i < 8; i++) {
        for (int j = 0; j < 8; j++) {
            disc[i][j] = 0;
        }
    }

    int op;
    int num;
    int cylinderNum;    //柱面号
    int trackNum;       //磁道号
    int physicalRecord;     //物理记录号

    while (1)
    {
        showMenu();
        cin>>op;
        switch (op)
        {
        case 1:
            cout << "请输入需要的块数：" << endl;
            cin >> num;
            occupy(disc,num,discLeft);
            displayBitMap(disc);
            break;
        case 2:
            cout << "请依次输入柱面号，磁道号，物理记录号：" << endl;
            cin>>cylinderNum>>trackNum>>physicalRecord;
            release(disc,cylinderNum,trackNum,physicalRecord,discLeft);
            displayBitMap(disc);
            break;
        case 0:
            return 0;
        default:
            break;
        }
    }
    
}