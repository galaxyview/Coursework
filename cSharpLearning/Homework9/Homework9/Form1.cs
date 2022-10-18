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

namespace Homework9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tx = textBox1.Text;
            bool flag = false;
            flag = Regex.IsMatch(tx, @"(\d){17}(\d|X|x)");
            if (flag)
            {
                if (isLegal(tx))
                {
                    label3.Text = "验证通过";
                }
                else
                {
                    label3.Text = "验证未通过";
                }
            }
            else
            {
                label3.Text = "验证未通过";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            label3.Text = null;
        }

        public bool isLegal(string IDNum)
        {
            int[] matches = new int[17];
            for(int i = 0; i < 17; i++)
            {
                matches[i] = IDNum[i] - 48;
            }
            int sum = 7 * matches[0] + 9 * matches[1] + 10 * matches[2] + 5 * matches[3] + 8 * matches[4] + 4 * matches[5] + 2 * matches[6] + matches[7] + 6 * matches[8] + 3 * matches[9] + 7 * matches[10] + 9 * matches[11] + 10 * matches[12] + 5 * matches[13] + 8 * matches[14] + 4 * matches[15] + 2 * matches[16];
            int remainder = sum % 11; //34052419800101001x
            char legal = '\n';
            switch (remainder)
            {
                case 0: legal = '1'; break;
                case 1: legal = '0'; break;
                case 2: legal = 'X'; break;
                case 3: legal = '9'; break;
                case 4: legal = '8'; break;
                case 5: legal = '7'; break;
                case 6: legal = '6'; break;
                case 7: legal = '5'; break;
                case 8: legal = '4'; break;
                case 9: legal = '3'; break;
                case 10: legal = '2'; break;
            }
            if (IDNum[17] == legal)
            {
                return true;
            }
            else
            {
                if((IDNum[17]=='x'|| IDNum[17] == 'X') && legal == 'X')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

}
