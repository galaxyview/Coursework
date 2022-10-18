using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace MagicTower
{
    public partial class StartGame : Form
    {
        SoundPlayer sp = new SoundPlayer();
        private string saveFile = @"Save\\map.txt";
        private string initialFile = @"Maps\\Initial.txt";
        LoadFile LoadForm;
        Game GameForm;

        public StartGame()
        {
            InitializeComponent();
        }

        //开始新游戏
        private void button_Start_Click(object sender, EventArgs e)
        {
            SoundEffect("SureSE");
            GameForm = new Game(initialFile);
            this.Hide();
            GameForm.ShowDialog();
            this.Close();
        }

        private void button_Read_Click(object sender, EventArgs e)
        {
            SoundEffect("SureSE");
            LoadForm = new LoadFile();
            this.Hide();
            LoadForm.ShowDialog();
            this.Close();
        }



        private void StartGame_Load(object sender, EventArgs e)
        {

        }

        private void SoundEffect(string s)
        {   
            sp.SoundLocation = $"Audio\\SE\\{s}.wav";
            sp.Play();
        }

    }
}
