using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace RestFulClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RestClient client = new RestClient();
            client.EndPoint = @"http://127.0.0.1:7788/";
            client.Method = EnumHttpVerb.POST;
            UserInfo info = new UserInfo();
            info.ID = long.Parse(this.textBox1.Text);
            info.Password = this.textBox2.Text;
            
            client.PostData = JsonConvert.SerializeObject(info);//JSon序列化我们用到第三方Newtonsoft.Json.dll
            var resultPost = client.HttpRequest("PersonInfoQuery/Login");
            if (resultPost.Length <= 2)
            {
                MessageBox.Show("输入的账号/密码有误，请重试！");
            }
            else
            {
                Form2 fm2 = new Form2();
                fm2.Show();
                this.Visible = false;
                
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
