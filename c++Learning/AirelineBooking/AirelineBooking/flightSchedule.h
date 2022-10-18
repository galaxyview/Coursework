//
//  FlightSchedule.h
//  AirelineBooking
//
//  Created by 邢宸亮 on 2020/7/10.
//  Copyright © 2020 邢宸亮. All rights reserved.
//

#ifndef FlightSchedule_h
#define FlightSchedule_h

class flightSchedule{
private:
    flight *first;
    flight *last;
    int flight_num;
    string password;
public:
    flightSchedule();
    flight *getFirst();
    flight *getLast();
    int getFlightNum();
    void add();
    void del();
    flight *search();
    void showAll();
    void showAllFlight();
    void setPassword();
    void resetPassword();
    string getPassword();
};

#endif /* FlightSchedule_h */
