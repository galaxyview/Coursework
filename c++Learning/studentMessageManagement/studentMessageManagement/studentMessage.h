//
//  studentMessage.h
//  studentMessageManagement
//
//  Created by 邢宸亮 on 2020/5/19.
//  Copyright © 2020 邢宸亮. All rights reserved.
//

#ifndef studentMessage_h
#define studentMessage_h

class studentMessage{
private:
    student * first;
    student * last;
    int num;
    string password;
public:
    studentMessage();
    student* getFirst();
    student* getLast();
    int getNum();
    void add();                             //向表中增加学生成绩记录
    void search();                          //在表中查找学生成绩记录
    void del();                             //在表中删除学生成绩记录
    void showAll();                         //输出所有学生的成绩
    void average();
    void sort();
    void clear();
    void setPassword();                     //设置系统管理密码
    void resetPassword();
    string getPassword();
};

#endif /* studentMessage_h */
