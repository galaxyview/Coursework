using System;

namespace Homework4._1
{
    public delegate void TimeHandler(object sender, TimeArgs args);
    
    
    public class TimeArgs
    {
        public int hour { get; set; }
        public int minute { get; set; }
        public int second { get; set; }
        
        public TimeArgs()
        {
            this.hour = this.minute = this.second = 0;
        }
        public TimeArgs(int hour,int minute,int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
    }
    public class Clock
    {
        TimeArgs t, alarm;
        public event TimeHandler Tick;
        public event TimeHandler Alarm;
        public Clock(int hour, int minute)  //构造函数设置时间
        {
            this.t = new TimeArgs();
            this.alarm = new TimeArgs();
            if (hour < 24 && minute < 60)
            {
                this.t.hour = hour;
                this.t.minute = minute;
                this.t.second = 0;
            }
            else
                this.t.hour = this.t.minute = this.t.second = 0;
        }
        
        public void setAlarm(int hour,int minute)
        {
            this.alarm.hour = hour;
            this.alarm.minute = minute;
        }

        public void Run()
        {
            while (true)
            {
                if (t.second < 59)
                {
                    t.second++;
                }
                else
                {
                    t.second = 0;
                    t.minute++;
                    if (t.minute == 60)
                    {
                        t.minute = 0;
                        t.hour++;
                        if (t.hour == 24)
                        {
                            t.hour = 0;
                        }
                    }
                }
                TimeArgs args = new TimeArgs(t.hour,t.minute,t.second);
                if (args.hour == alarm.hour && args.minute == alarm.minute && args.second == alarm.second)
                {
                    Alarm(this, args);
                }
                else
                {
                    Tick(this, args);
                }

                System.Threading.Thread.Sleep(1000);
                Console.Clear();

            }
        }
    }

    public class MyClock
    {
        public Clock myClock;
        public MyClock(int hour,int minute)
        {
            myClock = new Clock(hour, minute);
            myClock.Tick += tick;
            myClock.Alarm += alarm;
        }
        void tick(object sender, TimeArgs args)
        {
            Console.WriteLine(args.hour + ":" + args.minute + ":" + args.second);
        }
        void alarm(object sender,TimeArgs args)
        {
            Console.WriteLine("Alarm!");
        }

    }



    class Program
    {
        
        static void Main(string[] args)
        {
            int hour, minute;
            Console.WriteLine("请设置闹钟时间：");
            hour = int.Parse(Console.ReadLine());
            minute = int.Parse(Console.ReadLine());
            MyClock c = new MyClock(6, 0);
            c.myClock.setAlarm(hour, minute);
            c.myClock.Run();
        }
        
    }
}
