using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int max, min,temp,count;
        bool flag;

        public bool isnumeric(string str)
        {
            char[] ch = new char[str.Length];
            ch = str.ToCharArray();
            for (int i = 0; i<str.Length;i++  )  {
                if (ch[i] < 48 || ch[i] > 57)
                    return false;
            }
            return true;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex rex =
        new System.Text.RegularExpressions.Regex(@"^\d+$");
            if (rex.IsMatch(textBox2.Text) &&rex.IsMatch(textBox2.Text))
            {
                richTextBox1.Text = "";
                max = int.Parse(textBox1.Text);
                min = int.Parse(textBox2.Text);
                for (int i = min + 1; i < max; i++)
                {
                    temp = 1;
                    count = 0;
                    flag = false;
                    while (temp <= i / 2 + 1)
                    {
                        if (count >= 2)
                        {
                            flag = true;
                            break;
                        }
                        if (i % temp == 0)
                        {
                            count++;
                        }
                        temp++;
                    }
                    if (flag == false)
                    {
                        richTextBox1.Text += i.ToString() + " ";
                    }
                }
            }
            else
            {
                richTextBox1.Text = "输入有误,请重新输入！";
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}


