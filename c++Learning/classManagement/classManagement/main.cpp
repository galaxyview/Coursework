//
//  main.cpp
//  classManagement
//
//  Created by 邢宸亮 on 2020/10/24.
//

#include <iostream>
#define courseNum 12
using namespace std;

typedef struct LNode
{
    string id;//学号
    string name;//姓名
    string phoneNum;//电话
    string paphoneNum;//家长电话
    int kq[courseNum];//记录每次到课情况，1为出勤，0为缺勤,-1代表该课还没上,假定共有12次课
    bool first;//为true是头结点，为false是数据节点
    bool kdb;//头结点属性，为true代表有课代表，为false代表无课代表
    LNode* next;
}StuNode;

void Init(StuNode*& L)
{
    L = new StuNode;
    L->first = true;
}

void Delete(StuNode*& L)
{
    delete L;
}

void Create(StuNode*& L)
{
    cout << "开始创建班级..." << endl;
    L = new StuNode;
    L->next = NULL;
    L->first = true;
    StuNode* s, * r = L;
    cout << "请输入录入学生数量：" << endl;
    int i, num = 0;
    cin >> i;
    while (cin.fail())//输入为非数字，提示重新输入
    {
        cin.clear();
        cin.ignore();
        cout << "仅支持数字，请重新输入！" << endl;
        cin >> i;
    }
    for (; i > 0; i--)
    {
        cout << endl;
        num++;
        s = new StuNode;
        cout << "第" << num << "个学生" << endl;
        cout << "请输入学生学号：" << endl;
        cin >> s->id;
        cout << "请输入学生姓名：" << endl;
        cin >> s->name;
        cout << "请输入学生联系电话：" << endl;
        cin >> s->phoneNum;
        cout << "请输入学生家长联系电话：" << endl;
        cin >> s->paphoneNum;
        for (int j = 0; j < courseNum; j++)
        {
            s->kq[j] = -1;
        }
        s->first = false;
        s->next = NULL;
        r->next = s;
        r = s;
    }
    r->next = NULL;//尾指针始终指向NULL
}

bool choose(StuNode*& s) {
    if (s->next == NULL) {
        cout << "这是一个空班级" << endl;
        return false;
    }
    StuNode* L = new StuNode, * pre = s, * p = s->next, * q = L;
    int num, i = 0;
    cout << "请任意输入一个大于1的数字来选择课代表：" << endl;
    cin >> num;//循环报数
    while (cin.fail() || num <= 0)//输入不合理时提醒并重新输入
    {
        cin.clear();
        cin.ignore();
        cout << "输入有误，请重新输入！" << endl;
        cin >> num;
    }
    if (num == 1)
    {
        while (p->next != NULL)
        {
            pre = pre->next;
            p = p->next;
        }
        pre->next = NULL;
        p->next = s->next;
        s->next = p;
    }
    else
    {
        while (s->next->next != NULL)
        {
            p = s->next;
            pre = s;
            while (p != NULL) {
                i++;
                if (i == num) {
                    q->next = p;
                    pre->next = p->next;
                    q = p;
                    p->next = NULL;
                    p = pre->next;
                    i = 0;
                }
                else {
                    pre = pre->next;
                    p = p->next;
                }
            }
        }
        s->next->next = L->next;
    }
    delete L;
    s->kdb = true;
    return true;
}


void Changekq(StuNode*& s, bool all)
{
    int n, kqx;
    cout << "请输入要修改考勤的课次：" << endl;
    cin >> n;
    while (cin.fail() || n > courseNum)//输入不合理时提醒并重新输入
    {
        cin.clear();
        cin.ignore();
        cout << "输入有误，请重新输入！" << endl;
        cin >> n;
    }
    n--;
    if (all)//输入是头结点且需要全体操作，则修改全体考勤情况至到勤
    {
        StuNode* p = s->next;
        while (p != NULL)
        {
            p->kq[n] = 1;
            p = p->next;
        }
    }
    else//输入是数据节点，进行单个操作
    {
        cout << "请输入该次课出勤情况：（1代表出勤，0代表缺勤）" << endl;
        cin >> kqx;
        while (cin.fail() || (kqx != 1 && kqx != 0))//指令为非数字时提示有误
        {
            cin.clear();
            cin.ignore();
            cout << "考勤情况输入出错，请重新输入！" << endl;
            cin >> kqx;
        }
        s->kq[n] = kqx;
    }
}

void DisStu(StuNode* s)
{
    int d = 0, nd = 0;
    cout << "该学生学号：" << s->id << endl;
    cout << "该学生姓名：" << s->name << endl;
    cout << "该学生电话号码：" << s->phoneNum << endl;
    cout << "该学生家长电话号码：" << s->paphoneNum << endl;
    cout << "该学生考勤情况为：（“1”代表该生该次课出勤，“0”代表该生该次课缺勤，“-1”代表该次课未上）" << endl;
    for (int i = 0; i < courseNum; i++)
    {
        cout << s->kq[i] << " ";
        if (s->kq[i] == 1)d++;
        if (s->kq[i] == 0)nd++;
    }
    float cql;
    if ((d + nd) != 0)
    {
        cql = (d / (d + nd)) * 100;
        cout << "该学生的出勤率是：" << cql << "%" << endl;
    }
    else { cout << endl; }
    cout << "=========================================================================================================" << endl;
}

void ChangeStu(StuNode*& s)
{
    int order2;
    while (true)
    {
        cout << endl;
        cout << "请选择要修改的信息（学号，考勤不能在此处修改）：1.姓名。2.电话号码。3.家长电话号码。（输入需要修改的信息前的代号，输入0以退回上一级系统）" << endl;
        cin >> order2;
        while (cin.fail())//指令为非数字时提示有误
        {
            cin.clear();
            cin.ignore();
            cout << "仅支持数字指令，请重新输入！" << endl;
            cin >> order2;
        }
        switch (order2)
        {
        case 0://指令为0，退回上一级系统
            return;
        case 1://指令为1，修改姓名
            cout << "请输入新的学生姓名：";
            cin >> s->name;
            break;
        case 2://指令为2，修改电话号码
            cout << "请输入新的学生电话号码：";
            cin >> s->phoneNum;
        case 3://指令为3，修改家长电话号码
            cout << "请输入新的学生家长电话号码：";
            cin >> s->paphoneNum;
        default://指令不正确，提醒重新输入
            cout << "您的指令输入有误，请重新输入！" << endl;
            break;
        }
    }
    cout << "=========================================================================================================" << endl;
}

void Search(StuNode* L)
{
    string idx;
    cout << "请输入要查找学生的学号：" << endl;
    cin >> idx;
    StuNode* p = L->next, * pre = L;
    while (p != NULL && p->id != idx)
    {
        pre = pre->next;
        p = p->next;
    }
    if (p == NULL) { cout << "没有查找到该学生！" << endl; }
    else
    {
        cout << "该学生已找到。" << endl;
        int order1;
        while (true)
        {
            cout << "请选择要进行的操作：1.打印输出该学生信息。2.修改该学生的个人信息。3.操作该学生的考勤情况。4.删除该学生。0.退出查找系统。（请输入要进行的操作前面的代号）" << endl;
            cin >> order1;
            while (cin.fail())//指令为非数字时提示有误
            {
                cin.clear();
                cin.ignore();
                cout << "仅支持数字指令，请重新输入！" << endl;
                cin >> order1;
            }
            switch (order1)
            {
            case 0://指令为0，退出查找系统
                return;
            case 1://指令为1，输出学生信息
                DisStu(p);
                break;
            case 2://指令为2，修改学生个人信息
                ChangeStu(p);
                break;
            case 3://指令为3，操作学生考勤情况
                Changekq(p,false);
                break;
            case 4://指令为4，删除该学生并返回
                pre->next = p->next;
                delete p;
                return;
            default://指令不正确，提醒重新输入
                cout << "您的指令输入有误，请重新输入！" << endl;
                break;
            }
        }
    }
    cout << "=========================================================================================================" << endl;
}

void menu()
{
    StuNode* s;
    Create(s);
    choose(s);
    while (true)
    {
        cout << "=========================================================================================================" << endl;
        cout << "欢迎来到班级管理系统，请输入操作前的代号以进行操作：1.在班级中查找学生。2.输出课代表信息。3.操作班级全体考勤情况。4.生成班级报表。（输入0退出系统）" << endl;
        int orderM;
        string idy;
        StuNode* p = s->next;
        cin >> orderM;
        while (cin.fail())//指令为非数字时提示有误
        {
            cin.clear();
            cin.ignore();
            cout << "仅支持数字指令，请重新输入！" << endl;
            cin >> orderM;
        }
        switch (orderM)
        {
        case 0://指令为0，退出
            cout << "系统退出" << endl;
            return;
        case 1://指令为1，在班级中查找学生
            Search(s);
            break;
        case 2://指令为2，输出课代表信息
            cout << "课代表信息如下：" << endl;
            DisStu(s->next);
            break;
        case 3://指令为3，操作全体考勤情况(必须是课代表才能操作)
            cout << "请输入您的学号：" ;
            cin >> idy;
            if(idy!=s->next->id)//学号不为课代表的学号，退出
            {
                cout << "您不是课代表，无权限修改，退回上一级系统！" << endl;
                break;
            }
            else
            {
                Changekq(s, true);//修改全体考勤
                break;
            }
        case 4:
            while (p != NULL)//遍历并打印信息
            {
                DisStu(p);
                p = p->next;
            }
            break;
        default:
            cout << "指令输入有误，重新加载！" << endl;
            break;
        }
    }
    cout << "=========================================================================================================" << endl;
}

int main()
{
    menu();
    return 0;
}
