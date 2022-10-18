//
//  main.cpp
//  AirelineBooking
//
//  Created by 邢宸亮 on 2020/7/10.
//  Copyright © 2020 邢宸亮. All rights reserved.
//

#include <iostream>
#include <stdlib.h>
#include "flight.h"
#include "flightSchedule.h"
#include "passenger.h"
#include "passengerMessage.h"
using namespace std;

void showUserMenu(){
    cout << "                               \n";
    cout << "===============================\n";
    cout << "      菜单：\n\n";
    cout << "      1.航班信息查询\n";
    cout << "      2.乘客信息浏览\n";
    cout << "      3.订票\n";
    cout << "      4.退票\n";
    cout << "      5.返回上一级\n";
    cout << "      0.退出系统\n";
    cout << "===============================\n";
    cout << "                               \n";
}

void showAdmintstationMenu(){
    cout<<"                               \n";
    cout<<"===============================\n";
    cout<<"      菜单：\n\n";
    cout<<"      1.添加航班\n";
    cout<<"      2.删除航班\n";
    cout<<"      3.显示所有航班信息\n";
    cout<<"      4.更改系统管理密码\n";
    cout<<"      5.返回上一级\n";
    cout<<"      0.退出系统\n";
    cout<<"===============================\n";
    cout<<"                               \n";
}

flightSchedule::flightSchedule(){
    first = NULL;
    last = NULL;
    flight_num = 0;
}

flight * flightSchedule::getFirst(){
    return first;
}

flight * flightSchedule::getLast(){
    return last;
}

int flightSchedule::getFlightNum(){
    return flight_num;
}

void flightSchedule::add(){
    flight *t = new flight;
    flight *p = first;
    while(p){
        if(p->flightNumber==t->flightNumber){
            cout<<"\n航班号输入错误或该航班已存在(如需修改，请先删除再重新录入)"<<endl;
            return;
        }
        p=p->next;
    }
    flight_num++;
    if(first==NULL){
        first=last=t;
    }else{
        last->next=t;
        last=last->next;
    }
}

void flightSchedule::del(){
    string s;
    cout<<"\n请输入要删除的航班的的航班号: ";
    cin>>s;
    flight *t = first;
    flight *p = NULL;
    while(t){
           if(t->flightNumber==s)
               break;
           p=t;
           t=t->next;
    }
       if(!t){
           cout<<"\n未找到要删除的航班！"<<endl;
           return;
       }
       if(!p){
           first=first->next;
           cout<<"\n成功删除航班"<<s<<endl;
           delete t;
       }else{
           p->next=t->next;
           cout<<"成功删除航班"<<s<<endl;
           delete t;
       }
       
       flight_num--;
    
}

void flightSchedule::setPassword(){
    while (1) {
        cout<<"请设置一个长度大于6的管理员密码："<<endl;
        cin>>password;
        if (password.size() >= 6) {
            cout<<"密码设置成功！"<<endl;
            return;
        }else{
            cout<<"设置失败，请输入一个长度大于6的密码！"<<endl;
        }
    }
}

string flightSchedule::getPassword(){
    return password;
}

void flightSchedule::resetPassword(){
    string ps;
    cout<<"请输入旧密码：";
    cin>>ps;
    if (ps == password) {
        cout<<"请输入新密码：";
        cin>>ps;
    }else{
        cout<<"旧密码验证错误，请重新设置！"<<endl;
    }
}

void flightSchedule::showAll(){
    string a;
    int i = 1;
    cout<<"请输入您的终到站名称（终到站名称大写全拼）：";
    cin>>a;
    flight *t = first;
    cout<<"  航班号        剩余座位  "<<endl;
    while(t){
        if(t->destination==a){
            cout<<i<<" "<<t->flightNumber<<"        "<<t->seatLeft<<endl;
            i++;
        }
        t=t->next;
    }
    if(!t){
        cout<<"\n搜索完成！"<<endl;
        return;
    }
}

void flightSchedule::showAllFlight(){
    flight *t = first;
    cout<<"       航班号          总座位数              到达港  "<<endl;
    while (t) {
        cout<<"   \t"<<t->flightNumber<<"      \t"<<t->totalSeat<<"         \t"<<t->destination<<endl;
        t = t->next;
    }
    if (!t) {
        cout<<"所有航班搜索完成！"<<endl;
    }
}

flight * flightSchedule::search(){
    string a;
    cout<<"请输入航班号："<<endl;
    cin>>a;
    flight *t = first;
    while (t) {
        if (t->getFlightNumber() == a){
            return t;
            }
        t = t->next;
    }
    cout<<"航班信息输入有误！"<<endl;
    return NULL;
}

flight::flight(){
    cout<<"请输入航班号："<<endl;
    cin>>flightNumber;
    cout<<"请输入到达港的名称(到达港名称大写全拼）："<<endl;
    cin>>destination;
    cout<<"请输入总座位数："<<endl;
    cin>>totalSeat;
    seatLeft = totalSeat;
    psm = passengerMessage(totalSeat);
    next = NULL;
    cout<<"航班"<<flightNumber<<"已成功创建！"<<endl;
}

int flight::getTotalSeat(){
    return totalSeat;
}

string flight::getDestination(){
    return destination;
}

string flight::getFlightNumber(){
    return flightNumber;
}

void flight::minusSeatLeft(){
    seatLeft--;
}

void flight::addSeatLeft(){
    seatLeft++;
}

passengerMessage::passengerMessage(){
    first = NULL;
    last = NULL;
    passenger_num = 0;
}

passengerMessage::passengerMessage(int seatNum){
    first = NULL;
    last = NULL;
    passenger_num = 0;
    for (int i = 0; i<seatNum; i++) {
        seat[i] = i+1;
    }
    
}

passenger * passengerMessage::getFirst(){
    return first;
}

passenger * passengerMessage::getLast(){
    return last;
}

int passengerMessage::getPassengerNum(){
    return passenger_num;
}

void passengerMessage::add(int total){
    int stNum;
    if (passenger_num <= total) {
        passenger *t = new passenger;
        passenger *p = first;
        while (p) {
            if (p->IDNum == t->IDNum) {
                cout<<"该用户已购票，请勿重复购票！"<<endl;
                return;
            }
            p = p->next;
        }
        passenger_num++;
        cout<<"座位表（0为已经预定的座位）："<<endl;
        for (int i = 0; i<total; i++) {
            if (i%5 == 0) {
                cout<<endl;
            }
            cout<<seat[i]<<" ";
        }
        cout<<endl;
        cout<<"请输入您选择的座位号：";
        cin>>stNum;
        seat[stNum - 1] = 0;
        if (first == NULL) {
            cout<<"购票成功！"<<endl;
            t->setSeat(stNum);
            first = last = t;
        }else{
            cout<<"购票成功！"<<endl;
            t->setSeat(stNum);
            last->next = t;
            last = last->next;
        }
    }else{
        cout<<"该航班已无剩余座位！"<<endl;
    }
}

void passengerMessage::del(){
    string s;
    cout<<"\n请输入退票人的身份证号: ";
    cin>>s;
    passenger *t = first;
    passenger *p = NULL;
    while(t){
        if(t->IDNum==s)
            break;
        p=t;
        t=t->next;
    }
    if(!t){
        cout<<"\n未找到退票人，请核对后重试！"<<endl;
        return;
    }
    if(!p){
        seat[first->Seat -1] = first->Seat;
        first=first->next;
        cout<<"\n退票成功！"<<s<<endl;
        delete t;
    }else{
        seat[p->Seat -1] = p->Seat;
        p->next=t->next;
        cout<<"退票成功！"<<s<<endl;
        delete t;
    }
    passenger_num--;
}

void passengerMessage::showUserMessage(){
    string s;
    cout<<"请输入要查询的航班的航班号："<<endl;
    cin>>s;
    passenger *t = first;
    cout<<"乘客姓名           座位号"<<endl;
    while (t) {
        cout<<t->name<<"       \t"<<t->Seat<<endl;
        t = t->next;
    }
}



passenger::passenger(){
    cout<<"请输入订票人姓名："<<endl;cin>>name;
    cout<<"请输入订票人的身份证号："<<endl;cin>>IDNum;
    next = NULL;
}

void passenger::setSeat(int a){
    Seat = a;
}

int main() {
    int op1,op2,i;     //用来接收用户操作
    flightSchedule fs = flightSchedule();
    fs.setPassword();
    cout<<"================================================="<<endl;
    cout<<"                 欢迎使用票务系统                   "<<endl;
    cout<<"================================================="<<endl;
    op1 = 1;
    i = 1;
    while(1){
        cout<<"用户请输入1，系统管理人员请输入2，退出系统请输入0:"<<endl;
        cin>>op1;
        i = 1;
        while (i == 1) {
            switch (op1) {
                case 1:
                    while (i == 1) {
                        showUserMenu();
                        cout<< "请输入操作对应的序号: ";
                        cin >>op2;
                        cout << endl;
                        switch (op2) {
                            case 1:
                                fs.showAll();
                                break;
                            case 2:
                                fs.search()->psm.showUserMessage();
                                break;
                            case 3:
                                if (fs.search()) {
                                    flight *f1 = fs.search();
                                    f1->psm.add(f1->getTotalSeat());
                                    f1->minusSeatLeft();
                                }
                                break;
                            case 4:
                                if (fs.search()) {
                                    flight *f1 = fs.search();
                                    f1->psm.del();
                                    f1->addSeatLeft();
                                }
                                break;
                            case 5:
                                i = 0;
                                break;
                            case 0:
                                cout<<"\n退出成功！"<<endl;
                                return 0;
                            default:cout<<"\n输入序号有误！请输入正确的序号。"<<endl;
                        }
                        break;
                    case 2:
                        while (1) {
                            string ps;
                            cout<<"请输入系统管理密码："<<endl;
                            cin>>ps;
                            if (ps == fs.getPassword()) {
                                break;
                            }else{
                                if(ps == "0"){
                                    return 0;
                                }
                                cout<<"密码错误，请重新输入！"<<endl;
                                cout<<"忘记密码？请输入0以退出验证！"<<endl;
                            }
                        }
                        while (i == 1) {
                            showAdmintstationMenu();
                            cout<<"请输入操作对应的序号: "<<endl;
                            cin>>op2;
                            switch (op2) {
                                case 1:
                                    fs.add();
                                    break;
                                case 2:
                                    fs.del();
                                case 3:
                                    fs.showAllFlight();
                                     break;
                                case 4:
                                    fs.resetPassword();
                                case 5:
                                    i = 0;
                                    break;
                                case 0:
                                    return 0;
                                default:cout<<"\n输入序号有误！请输入正确的序号。"<<endl;
                                    break;
                            }
                        }
                        break;
                    case 0:
                        return 0;
                    default:
                        cout<<"操作编号输入有误，请重新尝试！"<<endl;
                        break;
                }
            }
        }
    }
}
    
    

