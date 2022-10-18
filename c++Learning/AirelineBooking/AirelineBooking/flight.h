//
//  Flight.h
//  AirelineBooking
//
//  Created by 邢宸亮 on 2020/7/10.
//  Copyright © 2020 邢宸亮. All rights reserved.
//

#ifndef Flight_h
#define Flight_h
#include "passengerMessage.h"
using namespace std;

class flight{
    friend class flightSchedule;
private:
    string flightNumber;     //航班号
    string destination;     //到达港
    int totalSeat;      //总座位数
    int seatLeft;
    flight *next;
public:
    flight();
    string getFlightNumber();
    string getDestination();
    int getTotalSeat();
    void minusSeatLeft();
    void addSeatLeft();
    flight *getNext();
    passengerMessage psm;
};

#endif /* Flight_h */
