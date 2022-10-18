//
//  passengerMessage.h
//  AirelineBooking
//
//  Created by 邢宸亮 on 2020/7/10.
//  Copyright © 2020 邢宸亮. All rights reserved.
//

#ifndef passengerMessage_h
#define passengerMessage_h
#include "passenger.h"

class passengerMessage{
private:
    passenger *first;
    passenger *last;
    int passenger_num;
    int seat[500];
public:
    passengerMessage();
    passengerMessage(int seatNum);
    passenger *getFirst();
    passenger *getLast();
    int getPassengerNum();
    void add(int total);
    void search();
    void del();
    void showAll();
    void showUserMessage();
};

#endif /* passengerMessage_h */
