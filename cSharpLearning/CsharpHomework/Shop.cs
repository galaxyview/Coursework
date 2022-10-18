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
    public partial class Shop : Form
    {
        public Shop(Hero hero)
        {
            InitializeComponent();
            this.hero = hero;
        }
        public Hero hero;
        //商店升级一种属性所消耗的金币
        public int fare = 100;
        SoundPlayer sp = new SoundPlayer();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hero.Money >= fare)
            {
                SoundEffect("SureSE");
                hero.Blood+=4000;
                hero.Money -= 100;
            }
            else
            {
                SoundEffect("NoMoneySE");
                MessageBox.Show("金币不足！");
            }
            
        }

        private void Shop_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (hero.Money >= fare)
            {
                SoundEffect("SureSE");
                hero.Attack += 20;
                hero.Money -= 100;
            }
            else
            {
                SoundEffect("NoMoneySE");
                MessageBox.Show("金币不足！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (hero.Money >= fare)
            {
                SoundEffect("SureSE");
                hero.Defence += 20;
                hero.Money -= 100;
            }
            else
            {
                SoundEffect("NoMoneySE");
                MessageBox.Show("金币不足！");
            }
        }


        private void SoundEffect(string s)
        {
            sp.SoundLocation = $"Audio\\SE\\{s}.wav";
            sp.Play();
        }

    }
}
