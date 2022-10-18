using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework4
{
    
    
    public partial class Form1 : Form
    {
        public Clock myClock;
        
        public Form1()
        {
            InitializeComponent();
            myClock = new Clock(6, 30);

            
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isnumeric(this.textBox1.Text) && isnumeric(this.textBox2.Text)) 
            {
                myClock.setAlarmHour(int.Parse(this.textBox1.Text));
                myClock.setAlarmMinute(int.Parse(this.textBox2.Text));
            }
            this.Run();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.Text = myClock.hours.ToString() + ":" + myClock.minute.ToString() + ":" + myClock.second.ToString();
        }

        public bool isnumeric(string str)
        {
            char[] ch = new char[str.Length];
            ch = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (ch[i] < 48 || ch[i] > 57)
                    return false;
            }
            return true;
        }

        public void Run()
        {
            this.myClock.tick += onTick;
            while (true)
            {
                if (this.myClock.second < 59) this.myClock.second++;
                else
                {
                    this.myClock.second = 0;
                    this.myClock.minute++;
                    if (this.myClock.minute == 60)
                    {
                        this.myClock.minute = 0;
                        this.myClock.hours = (this.myClock.hours + 1) % 24;
                    }
                }
                TimeArgs CurrentTime = new TimeArgs() { hours = this.myClock.hours, minute = this.myClock.minute, second = this.myClock.second };//当前时间
                if (this.myClock.hours == this.myClock.ahour && this.myClock.minute == this.myClock.aminute && this.myClock.second == this.myClock.asecond)
                {
                    this.label2.Text = myClock.hours.ToString() + ":" + myClock.minute.ToString() + ":" + myClock.second.ToString();
                }
                else
                {
                    this.label2.Text = myClock.hours.ToString() + ":" + myClock.minute.ToString() + ":" + myClock.second.ToString();
                }
                

            }
        }
        public void onTick(object sender, TimeArgs args)
        {

        }
    }


    public delegate void TickHandler(object sender, TimeArgs Args);

    

    public class TimeArgs
    {
        public int hours { get; set; }
        public int minute { get; set; }
        public int second { set; get; }
    }

    public class Clock
    {
        public int hours { get; set; }
        public int minute { get; set; }
        public int second { set; get; }
        public int ahour, aminute, asecond;//分别为当前时间和闹钟时间
        public event TickHandler tick;
        public event TickHandler alarm;
        public Clock(int hour, int minute)
        {
            if (minute < 60 && hour < 24)
            {
                this.hours = hour;
                this.minute = minute;
                this.second = 0;
            }
            else
            {
                this.hours = 0;
                this.minute = 0;
                this.second = 0;
            }
        }
        public void setAlarmHour(int hour)//设置闹钟时间
        {
            this.ahour = hour;
            this.asecond = 0;
        }

        public void setAlarmMinute(int minute)
        {
            this.aminute = minute;
        }
        
        
        
        
    }
    
}
