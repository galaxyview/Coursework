using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTower
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        
        


        private void button1_Click(object sender, EventArgs e)   //登录
        {
            string lname = textBox1.Text;
            string lpwd = textBox2.Text;

            if(Register.register.loginInformation.ContainsKey(lname)==false)
            {
                MessageBox.Show("该用户名尚未注册!", "Error");
            }
            else
            {
                string lvalue = Register.register.loginInformation[lname];
                if(lvalue!=lpwd)
                {
                    MessageBox.Show("密码输入错误!", "Error");
                }
                else
                {
                    MessageBox.Show("登录成功!", "Error");
                    StartGame form3 = new StartGame();
                    form3.ShowDialog();
                    this.Close();
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)  //取消
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)   //立即注册
        {
            Register register = new Register();
            this.Hide();
            register.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
