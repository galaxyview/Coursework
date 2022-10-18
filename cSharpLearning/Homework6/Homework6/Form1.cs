using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Homework6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt|";
            ofd.InitialDirectory = "C:\\";
            if (ofd.ShowDialog() == DialogResult.OK)
                textBox1.Text = System.IO.Path.GetFullPath(ofd.FileName);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt|";
            ofd.InitialDirectory = "C:\\";
            if (ofd.ShowDialog() == DialogResult.OK)
                textBox2.Text = System.IO.Path.GetFullPath(ofd.FileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=textBox2.Text&&textBox1.Text!= null&&textBox2.Text != null)
            {
                string[] lines1 = File.ReadAllLines(textBox1.Text, Encoding.UTF8);
                string[] lines2 = File.ReadAllLines(textBox2.Text, Encoding.UTF8);
                File.AppendAllLines("X:\\cSharpLearning\\Homework6\\Homework6\\Data\\1.txt", lines1, Encoding.UTF8);
                File.AppendAllLines("X:\\cSharpLearning\\Homework6\\Homework6\\Data\\1.txt", lines2, Encoding.UTF8);
                DialogResult dr = MessageBox.Show("合并完成！", "提示");

            }
            else
            {
                DialogResult dr = MessageBox.Show("路径选择有误，请重试！","提示");
            }
        }


    }

}
