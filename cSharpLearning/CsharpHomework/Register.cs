using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace MagicTower
{

    public partial class Register : Form
    {
        SoundPlayer sp = new SoundPlayer();
        public Register()
        {
            InitializeComponent();
            
        }

        public class register
        {
            public static Dictionary<string, string> loginInformation = new Dictionary<string, string>();
        }

        private void button1_Click(object sender, EventArgs e)   //提交注册
        {
            SoundEffect("SureSE");
            string name = textBox1.Text.Trim();
            string pwd = textBox2.Text.Trim();
            string agpwd = textBox3.Text.Trim();

            

            if (string.IsNullOrEmpty(name)||string.IsNullOrEmpty(pwd)||string.IsNullOrEmpty(agpwd))
            {
                SoundEffect("NoMoneySE");
                MessageBox.Show("用户名或密码不能为空！", "Error");
            }
            else if(name.Length>16)
            {
                SoundEffect("NoMoneySE");
                MessageBox.Show("用户名位数不正确！", "Error");
            }
            else if(pwd.Length<6||pwd.Length>16)
            {
                SoundEffect("NoMoneySE");
                MessageBox.Show("密码位数不正确！", "Error");
            }
            else if(register.loginInformation.ContainsKey(name)==true)
            {
                SoundEffect("NoMoneySE");
                MessageBox.Show("用户名已存在，请再次输入！", "Error");
            }
            else if(pwd!=agpwd)
            {
                SoundEffect("NoMoneySE");
                MessageBox.Show("两次输入密码不一致！", "Error");
            }
            else
            {
                SoundEffect("SureSE");
                register.loginInformation.Add(name, pwd);
                MessageBox.Show("注册成功！");
                Login login = new Login();
                login.Visible = true;
                this.Close();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)   //取消
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void SoundEffect(string s)
        {
            sp.SoundLocation = $"Audio\\SE\\{s}.wav";
            sp.Play();
        }
    }
}
