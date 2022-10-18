//
//  student.h
//  studentMessageManagement
//
//  Created by 邢宸亮 on 2020/5/19.
//  Copyright © 2020 邢宸亮. All rights reserved.
//

#ifndef student_h
#define student_h
using namespace std;
#include <string>

class student{
    friend class studentMessage;
private:
    string ID;
    string name;
    double score[5];                       //1-4代表chinese、math、English、c++和总成绩
    student *next;
public:
    student();
    string getName();
    string getStudentID();
    double getChinese();
    double getMath();
    double getEnglish();
    double getCPlusPlus();
    double getSum();
    double getAverage();
    student* getNext();
    
    void display();                          //打印成绩
    void swap();                          //交换对象和对象->next的信息
};


#endif /* student_h */
