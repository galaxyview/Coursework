using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace MagicTower
{
    public partial class LoadFile : Form
    {
        Game GameForm;
        String LoadPath;

        public LoadFile()
        {
            InitializeComponent();
        }






        private void button_Load_Click(object sender, EventArgs e)
        {
            //根据按钮名字获得存档编号
            Button bt = sender as Button;
            string no = Regex.Match(bt.Name, @"\d+$").Value;
            LoadPath = @"Save\\map" + no + @".txt";
            if (File.Exists(LoadPath))
            {
                GameForm = new Game(LoadPath);
                this.Hide();
                GameForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show($"map{no}文件不存在","Error");
            }
        }

        private void LoadFile_Load(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(@"Save\\map1.txt");
            label_time1.Text ="时间："+fi.LastWriteTime.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
