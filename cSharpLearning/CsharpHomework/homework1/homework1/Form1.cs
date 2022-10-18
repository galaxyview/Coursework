using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Form1 form1 = new Form1();
        Form2 form2 = new Form2();


        private void button1_Click(object sender, EventArgs e)   //登录
        {

        }

        private void button2_Click(object sender, EventArgs e)  //取消
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)   //立即注册
        {
            form2.ShowDialog();
            this.Hide();
            Application.ExitThread();
        }
    }
}
