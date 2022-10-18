//
//  main.cpp
//  studentMessageManagement
//
//  Created by 邢宸亮 on 2020/1/10.
//  Copyright © 2020 邢宸亮. All rights reserved.
//


#include<iostream>
#include<string>
#include<iomanip>
#include "student.h"
#include "studentMessage.h"
using namespace std;


student::student()
{
    cout<<"请输入学生学号 : ";cin>>ID;
    cout<<"请输入学生姓名 : ";cin>>name;
    cout<<"请输入学生的语文、数学、英语和c++成绩 : "<<endl;
    int a,b,c,d;
    cin>>a;
    while(a<0||a>100){
        cout<<"输入成绩有误，请重新输入: "<<endl;
        cin>>a;
    }
    cin>>b;
    while(b<0||b>100){
        cout<<"输入成绩有误，请重新输入: "<<endl;
        cin>>b;
    }
    cin>>c;
    while(c<0||c>100){
        cout<<"输入成绩有误，请重新输入: "<<endl;
        cin>>c;
    }
    cin>>d;
    while(d<0||d>100){
        cout<<"输入成绩有误，请重新输入: "<<endl;
        cin>>d;
    }
    score[0]=a;
    score[1]=b;
    score[2]=c;
    score[3]=d;
    score[4]=a+b+c+d;
    next=NULL;
}


string student::getName(){
    return name;
}

string student::getStudentID(){
    return ID;
}

double student:: getChinese(){
    return score[0];
}

double student:: getMath(){
    return score[1];
}

double student:: getEnglish(){
    return score[2];
}

double student:: getCPlusPlus(){
    return score[3];
}

double student:: getSum(){
    return score[4];
}

double student:: getAverage(){
    return score[4]/4;
}

student* student::getNext(){
    return next;
}



void student::display(){
    cout<<getName()<<"      \t"<<getStudentID()<<"    \t"<<getChinese()<<"  \t"<<getMath()<<"  \t"<<getEnglish()<<"  \t"<<getCPlusPlus()<<"  \t"<<getSum()<<"  \t"<<getAverage()<<endl;
}

void student::swap(){
    string na,id;
    double sco[5];
    na=name;name=next->name;next->name=na;
    id=ID;ID=next->ID;next->ID=id;
    for(int i=0;i<=4;i++){
        sco[i]=score[i];
        score[i]=next->score[i];
        next->score[i]=sco[i];
    }
}

student* studentMessage:: getFirst(){
    return first;
}

student* studentMessage:: getLast(){
    return last;
}

int studentMessage:: getNum(){
    return num;
}

studentMessage::studentMessage(){
    first=NULL;
    last=NULL;
    num=0;
}

void studentMessage::add()
{
    student *t = new student;
    student *p = first;
    while(p){
        if(p->ID==t->ID){
            cout<<"\n学号输入错误或该学生成绩已经存在！(如需修改，请先删除再重新录入)"<<endl;
            return;
        }
        p=p->next;
    }
    num++;
    if(first==NULL){
        first=last=t;
    }else{
        last->next=t;
        last=last->next;
    }
}

void studentMessage::search(){
    string a;
    cout<<"\n请输入要查找的学生的学号:";
    cin>>a;
    student *t = first;
    while(t){
        if(t->ID==a)
            break;
        t=t->next;
    }
    if(!t){
        cout<<"\n未找到要查找学生！"<<endl;
        return;
    }
    cout<<"\n查找成功！"<<endl;
    cout << "学生姓名—————————————————学号—————————————语文————数学————英语————c++————总分————平均分" << endl;
    t->display();
}

void studentMessage::del()
{
    string a,ps;
    cout<<"请验证系统管理密码："<<endl;
    cin>>ps;
    if (ps == getPassword()) {
    cout<<"\n请输入要删除的学生的学号: ";
    cin>>a;
    cout<<""<<endl;
    student *t = first;
    student *p = NULL;
    while(t){
        if(t->ID==a)
            break;
        p=t;
        t=t->next;
    }
    if(!t){
        cout<<"\n未找到要删除学生！"<<endl;
        return;
    }
    if(!p){
        first=first->next;
        cout<<"\n成功删除学生"<<a<<endl;
        delete t;
    }else{
        p->next=t->next;
        cout<<"成功删除学生"<<a<<endl;
        delete t;
    }
    
    num--;
    }else{
        cout<<"密码错误！"<<endl;
    }
}


void studentMessage::showAll(){
    string ps;
    cout<<"请验证系统管理密码："<<endl;
    cin>>ps;
        if (ps == getPassword()) {
            cout << "-------------------------------------------成绩列表------------------------------------------"<< endl;
            cout << "学生姓名—————————————————学号—————————————语文—---—数学—---—英语—---—c++—---—总分—---—平均分——---—" << endl;
            student *t = first;
            while(t){
                t->display();
                t=t->next;
            }
        }else{
            cout<<"密码错误！"<<endl;
        }
}

void studentMessage::average(){
    double sum = 0;
    double Csum = 0;
    double Msum = 0;
    double Esum = 0;
    double Cppsum = 0;
    student *t = first;
    while(t){
        sum += t->getAverage();
        Csum += t->getChinese();
        Msum += t->getMath();
        Esum += t->getEnglish();
        Cppsum += t->getCPlusPlus();
        t=t->next;
    }
    cout<<"语文——————数学——————英语——————c++——————平均"<<endl;
    cout<<Csum/num<<"      "<<Msum/num<<"      "<<Esum/num<<"       "<<Cppsum/num<<"      "<<sum/num;
}

void studentMessage::sort(){
    string ps;
    cout<<"请验证系统管理密码："<<endl;
    cin>>ps;
    if (ps == getPassword()) {
        int a,h = 0;
        while (1) {
            cout<<"请输入需要排序的科目（1-语文，2-数学，3-英语，4-c++，5-总分）："<<endl;
            cin>>a;
            if (a!=1&&a!=2&&a!=3&&a!=4&&a!=5) {
                cout<<"输入有误，请重新输入！"<<endl;
            }else{
                break;
            }
        }
        student* t = first;
        student* p = t;
        while (p->next) {
            t = first;
            while (t->next) {
                if (t->next->score[a] >= t->score[a]) {
                    t->swap();
                }
                t = t->next;
            }
            p = p->next;
        }
        t = first;
        cout<<"                       成绩排序                    "<<endl;
        cout<<"姓名                学号                    成绩     排名"<<endl;
        while (t) {
            h++;
            cout<<t->getName()<<"      \t"<<t->getStudentID()<<"        \t";
            switch (a) {
                case 1:
                    cout<<t->getChinese()<<"    \t"<<h<<endl;
                    break;
                case 2:
                    cout<<t->getMath()<<"    \t"<<h<<endl;
                    break;
                case 3:
                    cout<<t->getEnglish()<<"    \t"<<h<<endl;
                    break;
                case 4:
                    cout<<t->getCPlusPlus()<<"    \t"<<h<<endl;
                    break;
                case 5:
                    cout<<t->getAverage()<<"    \t"<<h<<endl;
                default:
                    break;
            }
            t = t->next;
        }
    }else{
        cout<<"密码错误！"<<endl;
    }
}

void studentMessage::clear(){
    string ps;
    int h;//用来接收用户的操作
    cout<<"请验证系统管理密码："<<endl;
    cin>>ps;
    if (ps == getPassword()) {
        cout<<"请问是否要清除所有的数据？（1-是，2-否）"<<endl;
        cin>>h;
        if (h == 2) {
            cout<<"清空已取消！"<<endl;
            return;
        }
        student* t = first;
        student* p;
        while (t) {
            p = t;
            t = t->getNext();
            delete p;
        }
        cout<<"系统已完成清空！"<<endl;
    }else{
        cout<<"密码错误！"<<endl;
    }
}

void studentMessage::setPassword(){
    while (1) {
        cout<<"请设置管理密码："<<endl;
        cin>>password;
        if (password.size() >= 6) {
            cout<<"密码设置成功"<<endl;
            return;
        }else{
            cout<<"设置失败，请重新设置一个长度大于6的密码！"<<endl;
        }
    }
}

void studentMessage::resetPassword(){
    string ps;
    while (1) {
        cout<<"请输入旧密码："<<endl;
        cin>>ps;
        if (ps == getPassword()) {
            setPassword();
            return;
        }else{
            cout<<"旧密码错误，请重试！"<<endl;
        }
    }
}

string studentMessage::getPassword(){
    return password;
}


void showMenu()
{
    cout << "                               \n";
    cout << "===============================\n";
    cout << "      学生成绩管理系统\n\n";
    cout << "      1.显示所有学生成绩\n";
    cout << "      2.添加学生信息\n";
    cout << "      3.查询学生信息\n";
    cout << "      4.删除学生信息\n";
    cout << "      5.计算学生平均成绩\n";
    cout << "      6.成绩排序\n";
    cout << "      7.清除系统中的数据\n";
    cout << "      8.重设密码\n";
    cout << "      0.退出系统\n";
    cout << "===============================\n";
    cout << "                               \n";
}




int main()
{
    int h;//用于接收用户的操作
    studentMessage stuM=studentMessage();
    stuM.setPassword();
    while(1)
    {
        showMenu();
        cout << "请输入操作对应的序号 : ";
        cin >>h;
        cout<<endl;
        switch(h)
        {
            case 1: stuM.showAll();
                break;
            case 2: stuM.add();
                break;
            case 3: stuM.search();
                break;
            case 4: stuM.del();
                break;
            case 5: stuM.average();
                break;
            case 6: stuM.sort();
                break;
            case 7: stuM.clear();
                break;
            case 8: stuM.resetPassword();
                break;
            case 0: cout<<"\n退出成功！";
                return 0;
            default:cout<<"\n输入序号有误！请输入正确的序号。"<<endl;
        }
    }
}
