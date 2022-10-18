using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Homework11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        Random rand = new Random();
        int i;
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            label2.Text = "请输入";
            //建立链接
            string connString = "Data Source = words.db";//数据库的数据格式为Num，Chinese，English
            SQLiteConnection connection = new SQLiteConnection(connString);
            connection.Open();
            
            //从数据库中随机抽取一个单词
            i = rand.Next(1, 5);
            string sql = "SELECT * FROM WORDS WHERE Num = "+i+";";

            //运用command和datareader读取数据库中的数据
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                label1.Text = (string)dataReader["Chinese"];
            }
            dataReader.Close();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //建立链接
                string connString = "Data Source = words.db";
                SQLiteConnection connection = new SQLiteConnection(connString);
                connection.Open();

                //从数据库中随机抽取一个单词
                string str = "";
                string sql = "SELECT * FROM WORDS WHERE Num = " + i + ";";

                //运用command和datareader读取数据库中的数据
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    str = (string)dataReader["English"];
                }
                dataReader.Close();

                //判断输入单词是否正确
                if (str == textBox1.Text)
                {
                    label2.Text = "正确";
                }
                else
                {
                    label2.Text = "错误";
                    textBox1.Text = str;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
