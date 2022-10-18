//
//  passenger.h
//  AirelineBooking
//
//  Created by 邢宸亮 on 2020/7/10.
//  Copyright © 2020 邢宸亮. All rights reserved.
//

#ifndef passenger_h
#define passenger_h
using namespace std;

class passenger{
    friend class passengerMessage;
private:
    string name;        //乘客姓名
    string IDNum;       //身份证号
    int Seat;        //座位号
    passenger *next;
    
public:
    passenger();
    void getName();
    void getID();
    void getSeat();
    void setSeat(int a);
    passenger* getNext();
};

#endif /* passenger_h */
